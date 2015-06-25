using System;
using System.Collections;

namespace Disperser
{
    public class StringDisperser : ICloneable, IComparable<StringDisperser>, IEnumerable
    {
        private string name1;
        private string name2;
        private string name3;

        public StringDisperser(string name1, string name2, string name3)
        {
            this.Name1 = name1;
            this.Name2 = name2;
            this.Name3 = name3;
        }

        public string Name1
        {
            get { return this.name1; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "Your name can not be null or empty");
                }

                this.name1 = value;
            }
        }

        public string Name2
        {
            get { return this.name2; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "Your name can not be null or empty");
                }

                this.name2 = value;
            }
        }

        public string Name3
        {
            get { return this.name3; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "Your name can not be null or empty");
                }

                this.name3 = value;
            }
        }

        public override bool Equals(object obj)
        {
            StringDisperser stringDisperser = obj as StringDisperser;

            if (stringDisperser == null)
            {
                return false;
            }

            else if (!(this.Name1.Equals(stringDisperser.Name1)))
            {
                return false;
            }

            else if (!(this.Name2.Equals(stringDisperser.Name2)))
            {
                return false;
            }

            else if (!(this.Name3.Equals(stringDisperser.Name3)))
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}", this.Name1, this.Name2, this.Name3);
        }

        public override int GetHashCode()
        {
            return this.Name1.GetHashCode() ^
                   this.Name2.GetHashCode() ^
                   this.Name3.GetHashCode();
        }

        public static bool operator ==(StringDisperser stringDisperser1, StringDisperser stringDisperser2)
        {
            return Equals(stringDisperser1, stringDisperser2);
        }

        public static bool operator !=(StringDisperser stringDisperser1, StringDisperser stringDisperser2)
        {
            return !Equals(stringDisperser1, stringDisperser2);
        }

        public object Clone()
        {
            StringDisperser clonedDisperser = new StringDisperser(this.Name1, this.Name2, this.Name3);
            return clonedDisperser;
        }

        public int CompareTo(StringDisperser other)
        {
            return this.ConcatenateNames(this).CompareTo(other.ConcatenateNames(other));
        }

        public IEnumerator GetEnumerator()
        {
            string allnames = this.ConcatenateNames(this);

            for (int i = 0; i < allnames.Length; i++)
            {
                yield return allnames[i];
            }
        }

        private string ConcatenateNames(StringDisperser stringDisperser)
        {
            string result = stringDisperser.Name1 + stringDisperser.Name2 + stringDisperser.Name3;
            return result;
        }
    }
}