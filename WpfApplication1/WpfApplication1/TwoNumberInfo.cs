using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC.Core.ComponentModel;

namespace WpfApplication1
{
    //public class TwoNumberInfo : INotifyPropertyChanged
    //{
    //    private int x = 0, y = 0;
    //    public int X
    //    {
    //        set
    //        {
    //            int oldValue = x;
    //            this.x = value;
    //            if (oldValue != this.x)
    //            {
    //                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(X)));
    //            }
    //        }
    //        get
    //        {
    //            return this.x;
    //        }
    //    }
    //    public int Y
    //    {
    //        set
    //        {
    //            int oldValue = y;
    //            this.y = value;
    //            if (oldValue != this.y)
    //            {
    //                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Y)));
    //            }
    //        }
    //        get
    //        {
    //            return this.y;
    //        }
    //    }

    //    /// <summary>
    //    /// 當屬性值發生變更時引發的事件
    //    /// </summary>
    //    public event PropertyChangedEventHandler PropertyChanged;
    //}

    public class TwoNumberInfo : NotifyPropertyChangedBase
    {
        private int x = 0, y = 0;
        private Operation operation;
        public int X
        {
            set
            {
                this.setPropertyAndNotifyOnChanged(value, t => this.x, t => t.X);
                //this.setPropertyAndNotifyOnChanged(value, t => this.x, t => t.X,new IntEqualityComparer());
                //this.notifyPropertyChanged(t => t.Y);
            }
            get
            {
                return this.x;
            }
        }
        public int Y
        {
            set
            {
                this.setPropertyAndNotifyOnChanged(value, t => this.y, t => t.Y);
                //this.setPropertyAndNotifyOnChanged(value, t => this.y, t => t.Y, new IntEqualityComparer());
            }
            get
            {
                return this.y;
            }
        }
        public Operation Operation
        {
            set
            {
                this.setPropertyAndNotifyOnChanged(value, t => this.operation, t => t.Operation);
            }
            get
            {
                return this.operation;
            }
        }
        //public class IntEqualityComparer : IEqualityComparer<int>
        //{
        //    public bool Equals(int x, int y)
        //    {
        //        return x == y;
        //    }
        //    public int GetHashCode(int obj)
        //    {
        //        return obj.GetHashCode();
        //    }
        //}
    }


}
