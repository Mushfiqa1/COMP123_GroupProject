using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    internal class Person
    {
        private string password;
        public event EventHandler<LoginEventArgs> OnLogin;
        public string Sin { get; }
        public string Name { get; }
        public bool IsAuthenticated { get; private set; }
        public Person(string name, string sin)
        {
            Name = name;
            Sin = sin;
            password = sin.Substring(0, 3);
        }

        public void Login(string password)
        {
            if (password != this.password)
            {
                IsAuthenticated = false;
                OnLogin?.Invoke(this, new LoginEventArgs(Name, false, LoginEventType.Login));
                throw new AccountException("Incorrect Password");
            }
            else
            {
                IsAuthenticated = true;
                OnLogin?.Invoke(this, new LoginEventArgs(Name, true, LoginEventType.Login));
            }
        }

        public void Logout()
        {
            IsAuthenticated = false;
            OnLogin?.Invoke(this, new LoginEventArgs(Name, true, LoginEventType.Logout));
        }
        public override string ToString()
        {
            return $"{Name} [{Sin}]";
        }
    }
}

