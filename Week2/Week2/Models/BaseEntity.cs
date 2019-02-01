using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Week2.Models
{
	public class BaseEntity<T>
	{
        // DB record key for fetching data
		public string ID { get; set; }
        // List identification
        public string Guid { get; set; }

        public BaseEntity()
        {
            Guid = System.Guid.NewGuid().ToString();
            ID = Guid; 
        }

	}
}