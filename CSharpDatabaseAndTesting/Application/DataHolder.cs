using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpDatabaseAndTesting.Application
{
    internal class DataHolder
    {

        private int data;

        public int Data {
            get {
                return data;
            }
            set
            {
                data = value;
            }
        }

        public int getData() {
            return this.data;
        }

        public void setData(int data) {
            this.data = data;
        }
    }

}
