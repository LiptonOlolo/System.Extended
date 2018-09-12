using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace System.System.Collections.Generic
{
    public class ExpressionList<T> : List<T>
    {
        public new void Remove<TKey>(Expression<Func<T, TKey>> expression, TKey key)
        {

        }
    }
}
