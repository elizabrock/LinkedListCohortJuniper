using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QuickGraph;
using SinglyLinkedLists;
using System.Reflection;

namespace SinglyLinkedListVisualizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BidirectionalGraph<object, IEdge<object>> _graphToVisualize;
        private SinglyLinkedList linkedList;

        public BidirectionalGraph<object, IEdge<object>> GraphToVisualize
        {
            get { return _graphToVisualize; }
        }

        public MainWindow()
        {
            InitializeLinkedList();
            _graphToVisualize = new BidirectionalGraph<object, IEdge<object>>();
            RefreshGraph();
            InitializeComponent();
            PopulateMethodList();
        }

        private void InitializeLinkedList()
        {
            linkedList = new SinglyLinkedList();
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            linkedList.Sort();
            RefreshGraph();
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            MethodInfo desiredMethod = linkedList.GetType().GetMethod((string)MethodList.SelectedValue);
            string arg1 = Argument1.Text;
            string arg2 = Argument2.Text;
            Argument1.Text = "";
            Argument2.Text = "";
            if (desiredMethod.GetParameters().Length == 1)
            {
                desiredMethod.Invoke(linkedList, new object[] { arg1 });
            }
            else
            {
                if (desiredMethod.GetParameters().First().ParameterType == typeof(int))
                {
                    desiredMethod.Invoke(linkedList, new object[] { Convert.ToInt32(arg1), arg2 });
                }
                else
                {
                    desiredMethod.Invoke(linkedList, new object[] { arg1, arg2 });
                }
            }
            RefreshGraph();
        }

        private void PopulateMethodList()
        {
            var methodList = new List<string>();
            foreach (MethodInfo methodInfo in typeof(SinglyLinkedList).GetMethods())
            {
                if (!methodInfo.IsStatic  && methodInfo.IsPublic)
                {
                    var methodParams = methodInfo.GetParameters();
                    if (methodInfo.ReturnType == typeof(void))
                    {
                        methodList.Add(methodInfo.Name);
                    }
                }

            }
            MethodList.ItemsSource = methodList;
        }

        // Original Source: https://www.youtube.com/watch?v=VTbuvkaPGxE
        private void RefreshGraph()
        {
            while (_graphToVisualize.Edges.Count() > 0)
            {
                _graphToVisualize.RemoveEdge(_graphToVisualize.Edges.First());
            }

            _graphToVisualize.AddVertex("SinglyLinkedList");
            _graphToVisualize.AddVertex("null");
            foreach(SinglyLinkedListNode node in SinglyLinkedListNode.allNodes){
                _graphToVisualize.AddVertex(node.ToString());
            }

            foreach (SinglyLinkedListNode node in SinglyLinkedListNode.allNodes)
            {
                if (node.Next == null)
                {
                    _graphToVisualize.AddEdge(new Edge<object>(node.ToString(), "null"));
                }
                else
                {
                    _graphToVisualize.AddEdge(new Edge<object>(node.ToString(), node.Next.ToString()));
                }
            }
            try
            {
                _graphToVisualize.AddEdge(new Edge<object>("SinglyLinkedList", linkedList.First() ?? "null"));
            }
            catch (NotImplementedException)
            {
                _graphToVisualize.AddEdge(new Edge<object>("SinglyLinkedList", "null"));
            }
        }
    }
}
