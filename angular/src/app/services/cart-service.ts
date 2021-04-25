import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import Decimal from 'decimal.js';
import { Cart, CartItem } from '../models/cart';
import { Product } from '../models/product';

@Injectable()
export class CartService {
	public cart: Cart;

	constructor(private http: HttpClient, @Inject('BASE_API_URL') private baseUrl: string) { 
		this.cart = new Cart();
	}

	public addItemToCart(product: Product) {
		var itemToUpdate = this.findCartItemByProductId(product.id)

		if (!itemToUpdate) {
			itemToUpdate = this.createNewItem(product);
			this.cart.items.push(itemToUpdate)
			this.recalculateItemPrice(itemToUpdate)
		}
		else
			this.increaseItemAmount(product.id)
	}

    public increaseItemAmount(productId: number) {
		var itemToUpdate = this.findCartItemByProductId(productId)

		if (!itemToUpdate)
			return;

		itemToUpdate.amount = new Decimal(itemToUpdate.amount).plus(1).toNumber();

		this.recalculateItemPrice(itemToUpdate);
    }	

	public reduceItemAmount(productId: number) {
		var itemToUpdate = this.findCartItemByProductId(productId)

		if (!itemToUpdate)
			return

		if (itemToUpdate.amount == 1) {
			this.remoteItemFromCart(productId)
			return
		}

		itemToUpdate.amount = new Decimal(itemToUpdate.amount).minus(1).toNumber();
		this.recalculateItemPrice(itemToUpdate);
	}

	private createNewItem(product: Product): CartItem {
		var item = new CartItem();
		item.id = this.getNewCartItemId();
		item.amount = 1;
		item.originalPrice = product.price;
		item.productName = product.name;
		item.productId = product.id;

		return item;
	}

	private remoteItemFromCart(productId: number) {
		var index = this.cart.items.findIndex(p => p.productId == productId);
		this.cart.items.splice(index, 1)
	}

	private getNewCartItemId(): number {
		if (this.cart && this.cart.items && this.cart.items.length > 0)
			return new Decimal(Math.max(...this.cart.items.map(p => p.id))).plus(1).toNumber();

		return 1;
	}

	private recalculateItemPrice(item: CartItem) {
		this.http.post<CartItem>(this.baseUrl + 'cart/recalculateitemprice', item).subscribe(result => {
			this.updateCartItem(item.productId, result)
		}, error => console.error(error));
	}

	private updateCartItem(productId: number, newItem: CartItem) {
		var cartItem =  this.findCartItemByProductId(productId)

		cartItem.originalPrice = newItem.originalPrice;
		cartItem.finalPrice = newItem.finalPrice;
		cartItem.isPromotion = newItem.isPromotion;
		cartItem.amount = newItem.amount;
	}

	private findCartItemByProductId(productId: number) {
		return this.cart.items.find(t => t.productId == productId);
	}
}