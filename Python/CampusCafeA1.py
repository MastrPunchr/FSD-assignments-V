# main.py  — A1 Campus Café Checkout (reference solution)

# --- Fixed menu (parallel lists) ---
MENU_NAMES = ["sandwich", "salad", "soup", "cookie", "coffee", "tea"]
MENU_PRICES = [6.50,       5.25,    4.25,   1.75,     2.50,    2.00]

TAX_RATE = 0.05  # 5%

def find_price_for(name):
    #TODO: I forgor :skull:
    """Return the price for an item name using the lists."""
    pass

def money(x):
    """Format a number like money, e.g., 3 -> "$3.00"."""
    return f"${x:.2f}"

def main():
    print("=== Campus Café Checkout ===")
    print("Menu:")
    # TODO: print menu items with prices
    
    print("-" * 32)

    # TODO: parse order, validate items, and compute totals

    # Receipt
    print("\n===== Campus Café Receipt =====")
    print("Items purchased:")
    # TODO: Print items purchased and show actual prices
    print("-" * 32)
    print(f"{'Subtotal:'}{'$0.00'}")
    print(f"{'Tax (5%):'}{'$0.00'}")
    print(f"{'TOTAL:'}{'$0.00'}")
    print("==============================")

if __name__ == "__main__":
    main()