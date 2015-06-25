using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerProgram
{
    public class Customer : ICloneable, IComparable<Customer>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private long id;
        private string permanentAdress;
        private string mobilePhone;
        private string email;
        private List<Payment> payments;
        private CustomerType customerType;

        public Customer(string firstName, string middleName, string lastName, long id, string permanentAdress,
            string mobilePhone, string email, List<Payment> payments, CustomerType customerType)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Id = id;
            this.PermanentAdress = permanentAdress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Payments = payments;
            this.CustomerType = customerType;
        }

        public Customer(string firstName, string middleName, string lastName, long id, string permanentAdress,
            string mobilePhone, string email, CustomerType customerType)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Id = id;
            this.PermanentAdress = permanentAdress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Payments = new List<Payment>();
            this.CustomerType = customerType;
        }

        public string FirstName
        {
            get { return this.firstName; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "Your name can not be null or empty");
                }

                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get { return this.middleName; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "Your name can not be null or empty");
                }

                this.middleName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "Your name can not be null or empty");
                }

                this.lastName = value;
            }
        }

        public long Id { get; set; }

        public string PermanentAdress
        {
            get { return this.permanentAdress; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "Your adress can not be null or empty");
                }

                this.permanentAdress = value;
            }
        }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public List<Payment> Payments { get; set; }

        public CustomerType CustomerType { get; set; }

        public override bool Equals(object obj)
        {
            Customer customer = obj as Customer;

            if (customer == null)
            {
                return false;
            }

            else if (!(Equals(this.FirstName, customer.FirstName)))
            {
                return false;
            }

            else if (!(Equals(this.MiddleName, customer.MiddleName)))
            {
                return false;
            }

            else if (!(Equals(this.LastName, customer.LastName)))
            {
                return false;
            }

            else if (this.Id != customer.Id)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder paymentsStringBuilder = new StringBuilder();

            if (this.Payments.Count != 0)
            {
                for (int i = 0; i < this.Payments.Count - 1; i++)
                {
                    paymentsStringBuilder.Append(this.Payments[i] + ", ");
                }

                paymentsStringBuilder.Append(this.Payments[this.Payments.Count - 1]);
            }

            return String.Format("First name: {0}, Middle name: {1}, Last name: {2}, Id: {3}, Permanent adress: {4}," +
                                 "Mobile phone: {5}, E-mail: {6}, Paymets: {7}, Customer type: {8}",
                this.FirstName, this.MiddleName, this.LastName, this.Id, this.PermanentAdress,
                this.MobilePhone, this.Email, paymentsStringBuilder, this.CustomerType);
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^
                   this.MiddleName.GetHashCode() ^
                   this.LastName.GetHashCode() ^
                   this.Id.GetHashCode() ^
                   this.PermanentAdress.GetHashCode() ^
                   this.MobilePhone.GetHashCode() ^
                   this.Email.GetHashCode() ^
                   this.Payments.GetHashCode() ^
                   this.CustomerType.GetHashCode();
        }

        public static bool operator ==(Customer customer1, Customer customer2)
        {
            return Equals(customer1, customer2);
        }

        public static bool operator !=(Customer customer1, Customer customer2)
        {
            return !Equals(customer1, customer2);
        }

        public object Clone()
        {
            Payment[] thisPayments = new Payment[this.Payments.Count];

            for (int i = 0; i < this.Payments.Count; i++)
            {
                thisPayments[i] = this.Payments[i];
            }

            Customer clonedCustomer = new Customer(this.FirstName, this.MiddleName, this.LastName, this.Id,
                this.PermanentAdress, this.MobilePhone, this.Email, thisPayments.ToList(), this.CustomerType);

            return clonedCustomer;
        }

        public int CompareTo(Customer other)
        {
            if (this.FirstName != other.FirstName)
            {
                return this.FirstName.CompareTo(other.FirstName);
            }

            return this.Id.CompareTo(other.Id);
        }
    }
}
