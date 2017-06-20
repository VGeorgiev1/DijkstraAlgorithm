using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
namespace DejikstraAlgorith
{

    public partial class Form1 : Form
    {
        public const int V = 18;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string srcCity = comboBox1.Text;
            string dest = comboBox2.Text;
            
            int src = 0;
            switch (srcCity)
            {
                case "Vidin":
                    src = 0;
                    break;
                case "Pleven":
                    src = 1;
                    break;
                case "Ruse":
                    src = 2;
                    break;
                case "Dobrich":
                    src = 3;
                    break;
                case "Varna":
                    src = 4;
                    break;
                case "Burgas":
                    src = 5;
                    break;
                case "Haskovo":
                    src = 6;
                    break;
                case "Kurjali":
                    src = 7;
                    break;
                case "Plovdiv":
                    src = 8;
                    break;
                case "Bansko":
                    src = 9;
                    break;
                case "Blagoevgrad":
                    src = 10;
                    break;
                case "Pernik":
                    src = 11;
                    break;
                case "Sofia":
                    src = 12;
                    break;
                case "Vraca":
                    src = 13;
                    break;
                case "V.Turnovo":
                    src = 14;
                    break;
                case "Sliven":
                    src = 15;
                    break;
                case "Shumen":
                    src = 16;
                    break;
                case "St.Zagora":
                    src = 17;
                    break;
            }




            int[,] graph =
            {
                // 1   2   3    4   5   6   7   8   9 10 11  12   13  14  15  16  17  18
                /*1.Vidin*/     {0, 211, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 124, 0, 0, 0, 0},
                /*2.Pleven*/    {211, 0, 150, 0, 0, 0, 0, 0, 0, 0, 0, 0, 162, 106, 127, 0, 0, 0},
       /*3.Ruse(Toshyko e tam)*/{0, 150, 0, 207, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 107, 0, 113, 0},
                /*4.Dobrich*/   {0, 0, 207, 0, 52, 0, 0, 0, 0, 0, 0, 0, 0, 0, 257, 0, 0, 0},
                /*5.Varna*/     {0, 0, 0, 52, 0, 115, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 88, 0},
                /*6.Burgas*/    {0, 0, 0, 0, 115, 0, 212, 0, 0, 0, 0, 0, 0, 0, 0, 113, 0, 0},
                /*7.Haskovo*/   {0, 0, 0, 0, 0, 212, 0, 47, 99, 0, 0, 0, 0, 0, 0, 0, 0, 60},
                /*8.Kurjali*/   {0, 0, 0, 0, 0, 0, 47, 0, 94, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                /*9.Plovdiv*/   {0, 0, 0, 0, 0, 0, 99, 94, 0, 147, 0, 0, 144, 0, 0, 0, 0, 101},
                /*10.Bansko*/   {0, 0, 0, 0, 0, 0, 0, 0, 147, 0, 82, 0, 155, 0, 0, 0, 0, 0},
              /*11.Blagoevgrad*/{0, 0, 0, 0, 0, 0, 0, 0, 0, 82, 0, 80, 0, 0, 0, 0, 0, 0},
                /*12.Pernik*/   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 82, 0, 42, 0, 0, 0, 0, 0},
                /*13.Sofia*/    {0, 162, 0, 0, 0, 0, 0, 0, 144, 155, 0, 42, 0, 110, 220, 307, 0, 0},
                /*14.Vraca*/    {124, 106, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 110, 0, 0, 0, 0, 0},
                /*15.V.Turnovo*/ {0, 127, 107, 257, 0, 0, 0, 0, 0, 0, 0, 0, 220, 0, 0, 112, 141, 106},
                /*16.Sliven*/   {0, 0, 0, 0, 0, 113, 0, 0, 0, 0, 0, 0, 307, 0, 112, 0, 135, 69},
                /*17.Shumen*/   {0, 0, 113, 0, 88, 0, 0, 0, 0, 0, 0, 0, 0, 0, 141, 135, 0, 0},
                /*18.St.Zagora*/ {0, 0, 0, 0, 0, 0, 60, 0, 101, 0, 0, 0, 0, 0, 106, 69, 0, 0}
            };
            string result = String.Empty;
            textBox1.Text = "Path:" + srcCity;
            result = dijkstra(graph, src, dest);
            double distance = double.Parse(result.Split().Last());
            double hoursNeeded = Math.Round(distance/80, 2);
            double minutesNeeded = 0;
            double minutes = 0;
            minutes = hoursNeeded - Math.Floor(hoursNeeded);
            minutesNeeded = Math.Floor((minutes*30)/0.5);      
            hoursNeeded = Math.Floor(hoursNeeded);
            string time = String.Empty;
            if (minutesNeeded >= 10)
            {
                time = hoursNeeded.ToString() + ":" + minutesNeeded.ToString();
            }
            else
            {
                time = hoursNeeded.ToString() + ":0" + minutesNeeded.ToString();
            }
            DateTime d = DateTime.ParseExact(time, "H:mm", CultureInfo.InvariantCulture);
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText(result);
            string hourMinutes = d.ToString("HH:mm");
            textBox1.AppendText(Environment.NewLine);
            textBox1.AppendText("Time for arrival(avg. speed 80km/h):"+hourMinutes+"h.");


        }

        private  string dijkstra(int[,] graph, int src, string dest)
        {
            int[] dist = new int[V]; // The output array.  dist[i] will hold the shortest
            // distance from src to i

            bool[] sptSet = new bool[V]; // sptSet[i] will true if vertex i is included in shortest
            // path tree or shortest distance from src to i is finalized
            int[] parent = new int[V];

            // Initialize all distances as INFINITE and stpSet[] as false
            for (int i = 0; i < V; i++)
            {
                parent[src] = -1;
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            // Distance of source vertex from itself is always 0
            dist[src] = 0;

            // Find shortest path for all vertices
            for (int count = 0; count < V - 1; count++)
            {
                // Pick the minimum distance vertex from the set of vertices not
                // yet processed. u is always equal to src in first iteration.
                int u = minDistance(dist, sptSet);

                // Mark the picked vertex as processed
                sptSet[u] = true;

                // Update dist value of the adjacent vertices of the picked vertex.
                for (int v = 0; v < V; v++)

                    // Update dist[v] only if is not in sptSet, there is an edge from 
                    // u to v, and total weight of path from src to  v through u is 
                    // smaller than current value of dist[v]
                    if (!sptSet[v] && graph[u, v] != 0 && dist[u] != int.MaxValue
                        && dist[u] + graph[u, v] < dist[v])
                    {
                        parent[v] = u;
                        dist[v] = dist[u] + graph[u, v];

                    }
            }

            // print the constructed distance array
            
            string srcCity = String.Empty;
            string city = String.Empty;
            int b = 0;
            for (; b < V; b++)
            {

                switch (b)
                {
                    case 0:
                        city = "Vidin";
                        break;
                    case 1:
                        city = "Pleven";
                        break;
                    case 2:
                        city = "Ruse";
                        break;
                    case 3:
                        city = "Dobrich";
                        break;
                    case 4:
                        city = "Varna";
                        break;
                    case 5:
                        city = "Burgas";
                        break;
                    case 6:
                        city = "Haskovo";
                        break;
                    case 7:
                        city = "Kurjali";
                        break;
                    case 8:
                        city = "Plovdiv";
                        break;
                    case 9:
                        city = "Bansko";
                        break;
                    case 10:
                        city = "Blagoevgrad";
                        break;
                    case 11:
                        city = "Pernik";
                        break;
                    case 12:
                        city = "Sofia";
                        break;
                    case 13:
                        city = "Vraca";
                        break;
                    case 14:
                        city = "V.Turnovo";
                        break;
                    case 15:
                        city = "Sliven";
                        break;
                    case 16:
                        city = "Shumen";
                        break;
                    case 17:
                        city = "St.Zagora";
                        break;
                }
                if (city == dest)
                {
                    switch (src)
                    {
                        case 0:
                            srcCity = "Vidin";
                            break;
                        case 1:
                            srcCity = "Pleven";
                            break;
                        case 2:
                            srcCity = "Ruse";
                            break;
                        case 3:
                            srcCity = "Dobrich";
                            break;
                        case 4:
                            srcCity = "Varna";
                            break;
                        case 5:
                            srcCity = "Burgas";
                            break;
                        case 6:
                            srcCity = "Haskovo";
                            break;
                        case 7:
                            srcCity = "Kurjali";
                            break;
                        case 8:
                            srcCity = "Plovdiv";
                            break;
                        case 9:
                            srcCity = "Bansko";
                            break;
                        case 10:
                            srcCity = "Blagoevgrad";
                            break;
                        case 11:
                            srcCity = "Pernik";
                            break;
                        case 12:
                            srcCity = "Sofia";
                            break;
                        case 13:
                            srcCity = "Vraca";
                            break;
                        case 14:
                            srcCity = "V.Turnovo";
                            break;
                        case 15:
                            srcCity = "Sliven";
                            break;
                        case 16:
                            srcCity = "Shumen";
                            break;
                        case 17:
                            srcCity = "St.Zagora";
                            break;
                    }
                    break;
                }


            }
            printPath(parent,b);
            return "From " + srcCity + " to " + city + " -> " + dist[b];
        }

        private static int minDistance(int[] dist, bool[] sptSet)
        {
            // Initialize min value
            int min = int.MaxValue;
            int min_index = 0;

            for (int v = 0; v < V; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;
        }

       void printPath(int[] parent, int i)
        {
            // Base Case : If j is source
            if (parent[i] == -1)
                return;

            printPath(parent, parent[i]);
            string city = String.Empty;
            switch (i)
            {
                case 0:
                    city = "Vidin";
                    break;
                case 1:
                    city = "Pleven";
                    break;
                case 2:
                    city = "Ruse";
                    break;
                case 3:
                    city = "Dobrich";
                    break;
                case 4:
                    city = "Varna";
                    break;
                case 5:
                    city = "Burgas";
                    break;
                case 6:
                    city = "Haskovo";
                    break;
                case 7:
                    city = "Kurjali";
                    break;
                case 8:
                    city = "Plovdiv";
                    break;
                case 9:
                    city = "Bansko";
                    break;
                case 10:
                    city = "Blagoevgrad";
                    break;
                case 11:
                    city = "Pernik";
                    break;
                case 12:
                    city = "Sofia";
                    break;
                case 13:
                    city = "Vraca";
                    break;
                case 14:
                    city = "V.Turnovo";
                    break;
                case 15:
                    city = "Sliven";
                    break;
                case 16:
                    city = "Shumen";
                    break;
                case 17:
                    city = "St.Zagora";
                    break;
            }
             textBox1.AppendText("->"+city);
        }

    }
}

