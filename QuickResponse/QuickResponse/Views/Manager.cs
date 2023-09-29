using System;

namespace QuickResponse.Views
{
    internal class Manager
    {
        private string v1;
        private string v2;

        public Manager(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        internal object SendMessage(string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}