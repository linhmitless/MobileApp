using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Week2.Models
{
	public class Entity<T>: BaseEntity<T>
	{
        // The name of Item/Character/Monster shown to users
		public string Name { get; set; }
        // The description of Item/Character/Monster shown to users
        public string Description { get; set; }
        // The image of the Entity, will come from a server. 
        // A photo fetched from the URI will be presented to user 
        public string ImageURI { get; set; }
	}
}