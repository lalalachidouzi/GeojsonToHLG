using Newtonsoft.Json.Linq;

Console.WriteLine("输入geojson：");
var jsonpath = Console.ReadLine();
var jsonstr = File.ReadAllText(jsonpath);

var jobj = JObject.Parse(jsonstr);

var features = jobj["features"] as JArray;
var feature = features[0];
var geometry = feature["geometry"];
var coordinates = geometry["coordinates"] as JArray;
var coordinate = coordinates[0] as JArray;
var c = coordinate[0];


// 文件路径
string outputPath = Path.Combine(Path.GetDirectoryName(jsonpath), "output.txt");

// 使用 StreamWriter 以追加方式打开文件
using StreamWriter writer = new StreamWriter(outputPath, true);

writer.WriteLine("[HIGHLIGHTING]");
writer.WriteLine("zoom=14");

int count = 0;
foreach (var item in c)
{
    var point = item as JArray;
    writer.WriteLine($"PointLon_{count.ToString()}={point[0].ToString()}");
    writer.WriteLine($"PointLat_{count.ToString()}={point[1].ToString()}");
    count++;
}