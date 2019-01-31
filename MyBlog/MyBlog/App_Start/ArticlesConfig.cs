using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog
{
    public class ArticlesConfig
    {
        public static void Initialize()
        {
            Articles.Instance.AddRange(new[]
            {
                new Article(){ Title="Chimi", Date=DateTime.Now, Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed posuere urna et magna dictum aliquet et ac massa. Maecenas mauris tortor, mollis vitae maximus et, tempor id felis. In scelerisque, nibh vitae condimentum euismod, sem turpis egestas tortor, finibus feugiat ante lacus et orci. Vestibulum eros justo, aliquam nec facilisis eu, dignissim ac est. Vestibulum efficitur nibh ultricies risus sagittis vestibulum. Sed fermentum libero nisi, placerat ornare lacus viverra a. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Praesent gravida nulla eu pretium condimentum. Donec at blandit ligula, ac sagittis risus. Suspendisse at venenatis quam, at viverra erat. Morbi laoreet sed leo sed aliquam. Cras et pulvinar dolor. Suspendisse et mattis purus, sed dictum metus. Integer sit amet ligula sed lacus rhoncus ullamcorper. Cras ac semper sapien." },
                new Article(){ Title="Rando", Date=DateTime.Now, Text="Nunc hendrerit ornare mauris eu venenatis. Morbi malesuada pretium dignissim. Sed at tellus efficitur, aliquet ante pellentesque, accumsan neque. Ut vitae sodales ligula. Nulla vehicula nunc quis bibendum auctor. Mauris sagittis, sapien sed gravida mollis, libero ante posuere sapien, sit amet porta odio lorem eu augue. Nunc maximus id lectus a commodo. Nulla auctor fringilla mollis. Praesent ac justo a augue varius luctus non quis elit. Aliquam erat volutpat. Phasellus tincidunt ex in commodo elementum. Suspendisse ut efficitur nulla, sed rhoncus ante." },
                new Article(){ Title="Colapse", Date=DateTime.Now, Text="Nunc luctus odio sed massa luctus commodo. Nullam mauris dui, pulvinar sit amet finibus ut, eleifend vitae magna. Sed non orci consectetur, pulvinar mi sit amet, laoreet eros. Proin euismod turpis orci, sit amet dignissim ligula accumsan a. Morbi euismod dictum massa eu laoreet. Quisque sed neque sem. Etiam tempus sit amet sapien id venenatis. Nullam sit amet dui nec urna molestie facilisis." },
                new Article(){ Title="Hotspot", Date=DateTime.Now, Text="Mauris eu neque elit. Duis nulla magna, feugiat sit amet nisi ut, vulputate pulvinar arcu. Aliquam facilisis justo eu leo vulputate pulvinar. Vestibulum eget condimentum leo. Pellentesque rhoncus turpis dui. Integer tristique mi quis interdum porta. Sed orci tortor, tristique et pharetra eu, egestas ut urna. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Etiam blandit augue eget orci tristique, in pretium nisl interdum. Aliquam est ligula, maximus quis maximus sit amet, pretium finibus justo. Nulla posuere tortor eget auctor mollis. Quisque dignissim finibus sapien eget volutpat. Etiam non nisl ut libero sagittis eleifend molestie vitae augue. Praesent id molestie orci. Maecenas urna libero, sodales dapibus nibh sed, hendrerit porttitor velit." },
                new Article(){ Title="Criminals", Date=DateTime.Now, Text="Fusce vestibulum ullamcorper dictum. Curabitur convallis congue consectetur. Maecenas placerat lectus interdum interdum posuere. Proin tincidunt egestas velit, non mattis risus sagittis mattis. Nunc ultricies sapien lectus, sit amet vestibulum nunc placerat sit amet. Fusce porta sem vulputate nisl consequat sagittis. Nulla gravida tortor sit amet orci gravida scelerisque. Aenean eleifend sem odio, vel semper erat tincidunt at. Fusce vehicula faucibus libero, vel porta mauris ornare eget. Duis vehicula ante vel nunc posuere, quis hendrerit nisl posuere." },
            }
                );
        }
    }
}