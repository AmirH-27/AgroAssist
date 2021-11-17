using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroAssistUpdated {
    public class UserInfo {
        static string name ;
        static string fName;

        public string Name { get; set; }

        public void setName(string a) {
            name = a;
        }

        public string getName() {
            return name;
        }
        public void setFName(string a) {
            fName = a;
        }

        public string getFName() {
            return fName;
        }


    }
}
