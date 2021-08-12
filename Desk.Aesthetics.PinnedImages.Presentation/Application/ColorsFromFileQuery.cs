using Data.Common.Contracts;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Media;

namespace Desk.Aesthetics.PinnedImages.Presentation.Application
{
    class ColorsFromJsonFileQuery : IQuery<IEnumerable<Color>, string> //TParameter is the filepath for colors.json
    {
        public IEnumerable<Color> Execute(string parameter)
        {
            string fileTextContents = File.ReadAllText(parameter);

            JArray array = JArray.Parse(fileTextContents);

            string[] colors = array.ToObject<string[]>();

            return from item in colors
                   select (Color)ColorConverter.ConvertFromString(item);
        }
    }
}
