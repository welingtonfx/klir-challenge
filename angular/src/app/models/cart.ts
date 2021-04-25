export class Cart {
	items: CartItem[] = new Array<CartItem>();
	total: number;
}

export class CartItem {
	id: number;
	productId: number;
	productName: string;
	isPromotion: boolean;
	originalPrice: number;
	finalPrice: number;
	amount: number;
}