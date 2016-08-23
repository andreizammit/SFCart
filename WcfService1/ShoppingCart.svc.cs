using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SFCart
{
    public class ShoppingCart : ICart
    {
        // List of Items available for sale
        private static List<Item> STORE = null;

        // List of Items in cart
        private static List<Item> CART = null;

        // Current status of cart
        private static Status STATUS = null;

        public ShoppingCart()
        {

        }

        public bool AddItem(int id)
        {
            bool success = false;

            try
            {
                // Check if Item is in Store
                Item item = Store.Find(x => x.ID == id);

                // If item is not found in cart, check in items available
                if (item == null)
                {
                    Status.Detail = string.Empty;
                    Status.State = Status.STATE.Error;
                    Status.Message = "Item not found!";
                }
                else
                {
                    Item itemInCart = Cart.Find(x => x.ID == id);

                    if (itemInCart == null)
                    {
                        item.Amount = 1;
                        Cart.Add(item);
                        Status.Detail = string.Empty;
                        Status.State = Status.STATE.OK;
                        Status.Message = "New Item added!";

                        success = true;
                    }
                    else
                    {
                        item.Amount++;
                        Status.Detail = string.Format("Item {0} increased to {1}", item.Name, item.Amount);
                        Status.State = Status.STATE.OK;
                        Status.Message = "Item added!";

                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Status.Detail = ex.Message;
                Status.State = Status.STATE.Error;
                Status.Message = "Could not add item!";
            }

            return success;
        }

        public bool RemoveItem(int id)
        {   
            bool success = false;

            try
            {
                Item item = Cart.Find(x => x.ID == id);
                // If item is not found in cart, check in items available
                if (item != null)
                { 
                    success = Cart.Remove(item);
                }

                if (success)
                {
                    Status.Detail = string.Empty;
                    Status.State = Status.STATE.OK;
                    Status.Message = "Item was  removed.";
                }
                else
                {
                    Status.Detail = string.Empty;
                    Status.State = Status.STATE.Error;
                    Status.Message = "Item to remove was not found in cart!";
                }
            }
            catch (Exception ex)
            {
                Status.Detail = ex.Message;
                Status.State = Status.STATE.Error;
                Status.Message = "Could not remove item from cart!";
            }

            return success;
        }

        public bool ClearItems()
        {
            bool success = false;

            try
            {
                Cart.Clear();

                Status.Detail = string.Empty;
                Status.State = Status.STATE.OK;
                Status.Message = "Cart cleared.";

                success = true;
            }
            catch (Exception ex)
            {
                Status.Detail = ex.Message;
                Status.State = Status.STATE.Error;
                Status.Message = "Could clear cart!";
            }

            return success;
        }

        /// <summary>
        /// Generate a list of available items for sale
        /// </summary>
        /// <returns>List of items for sale</returns>
        public List<Item> GetItems()
        {
            try
            {
                if (STORE == null)
                {
                    STORE = new List<Item>();
                    STORE.Add(new Item(1, 10.50, "Flowers 1", 0));
                    STORE.Add(new Item(2, 12.99, "Flowers 2", 0));
                    STORE.Add(new Item(3, 44.99, "Flowers 3", 0));
                    STORE.Add(new Item(4, 28.50, "Flowers 4", 0));
                    STORE.Add(new Item(5, 17.50, "Flowers 5", 0));
                    STORE.Add(new Item(6, 34.99, "Flowers 6", 0));
                }
            }
            catch (Exception ex)
            {
                Status.Detail = ex.Message;
                Status.State = Status.STATE.Error;
                Status.Message = "Error encountered whilst generating list of items available!";
            }
            return STORE;
        }

        /// <summary>
        /// Generate a list of available items for sale
        /// </summary>
        /// <returns>List of items for sale</returns>
        public List<Item> GetCartItems()
        {
            return Cart;
        }

        public List<Item> GetStoreItems()
        {
            return Store;
        }

        public Status GetStatus()
        {
            return Status;
        }

        private List<Item> Cart
        {
            get
            {
                if (CART == null)
                    CART = new List<Item>();

                return CART;
            }

            set
            {
                CART = value;
            }
        }

        private List<Item> Store
        {
            get
            {
                if (STORE == null)
                    GetItems();

                return STORE;
            }

            set
            {
                STORE = value;
            }
        }

        private Status Status
        {
            get
            {
                if (STATUS == null)
                    STATUS = new Status();

                return STATUS;
            }

            set
            {
                STATUS = value;
            }
        }
    }
}
