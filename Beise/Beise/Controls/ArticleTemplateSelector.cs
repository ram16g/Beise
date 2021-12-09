using Beise.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Beise.Controls
{
    public class AticleTemplateSelector : DataTemplateSelector
    {
        public DataTemplate OneTemplate { get; set; }
        public DataTemplate ThreeTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var articleItem = item as ArticleListResult.Item;
            return articleItem.img_info.imgs.Count > 1 ? ThreeTemplate : ThreeTemplate;
        }
    }
}
