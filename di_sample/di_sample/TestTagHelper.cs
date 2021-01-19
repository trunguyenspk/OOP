using Dynamitey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using di_sample.Models;

namespace di_sample
{
    public class TestTagHelper : TagHelper
    {
        public TestTagHelper(IRepository myRepository)
        {
            MyTalkRepository = myRepository;
        }
        public IRepository MyTalkRepository { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "h1";
            //output.Content.SetContent("From TagHelper - " + MyTalkRepository.GetnUpdateCounter().ToString());
            output.Content.SetContent("From TagHelper - " + MyTalkRepository.GetHashCode());
        }
    }
}
