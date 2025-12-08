MENU_NAMES = ["sandwich", "salad", "soup", "cookie", "coffee", "tea"]
MENU_PRICES = [6.50,    5.25,    4.25,   1.75,     2.50,    2.00]

TAX_RATE = 0.05  # 5%
items_ordered = []

def find_price_for(name):
    item, qty = name.split(":")
    if item in MENU_NAMES and int(qty) > 0:
        items_ordered.append(f"{item}{'x'}{qty}")
        price_index = MENU_NAMES.index(item)
        item_price = MENU_PRICES[price_index] * float(qty)
        return item_price
    else:
        print("Shlawg....")
        return 0

def money(x):
    """Format a number like money, e.g., 3 -> "$3.00"."""
    return f"${x:.2f}"

def main():
    print("==== Campus Café Checkout ====")
    print("Menu:")
    """Prints menu items"""
    for item, cost in zip(MENU_NAMES, MENU_PRICES): 
       price = money(cost)
       print(f"\n{item:<18} Price:{price}")
    
    print("-" * 30)
    order_cost = 0
    user_order = input("Input order (item:qty):")
    order_items = user_order.split()

    for item in order_items:
        price = find_price_for(item)
        order_cost += price

    # Receipt
    print("\n==== Campus Café Receipt ====")
    print(f"{'Items purchased:'}{items_ordered}")
    # TODO: Print items purchased and show actual prices
    print("-" * 30)
    print(f"{'Subtotal: '}{money(order_cost)}")
    print(f"{'Tax (5%): '}{money(order_cost * TAX_RATE)}")
    print(f"{'TOTAL: '}{money(order_cost + order_cost * TAX_RATE)}")
    print("=" * 30)

if __name__ == "__main__":
    main()