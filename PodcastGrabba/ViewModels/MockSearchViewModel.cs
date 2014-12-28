using Infrastructure;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodcastGrabba.ViewModels
{
    public class MockSearchViewModel : ViewModel
    {
        private IList<string> items = new List<string>();

        public MockSearchViewModel()
        {
            for (var i = 0; i < 50; i++)
            {
                this.items.Add(i.ToString());
            }
        }

        public IEnumerable<string> Items
        {
            get
            {
                return this.items;
            }
        }

        public int SearchProgress
        {
            get
            {
                return 50;
            }
        }
    }
}
