using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroAssistUpdated {
    public class Receipt {
        static string token, breed, color, weight, price, totalPrice, name;

        public void setToken(string t) {
            token = t;
        }
        public string getToken() {
            return token;
        }
        public void setBreed(string t) {
            breed = t;
        }
        public string getBreed() {
            return breed;
        }

        public void setColor(string t) {
            color = t;
        }
        public string getColor() {
            return color;
        }

        public void setWeight(string t) {
            weight = t;
        }
        public string getWeight() {
            return weight;
        }

        public void setPrice(string t) {
            price = t;
        }
        public string getPrice() {
            return price;
        }
        public void setTotal(string t) {
            totalPrice = t;
        }
        public string getTotal() {
            return totalPrice;
        }
        public void setName(string t) {
            name = t;
        }
        public string getName() {
            return name;
        }
    }


}
