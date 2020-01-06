using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualSort
{
    public sealed partial class Form1 : Form
    {
        private int[] _arr;
        private List<int> _randomArray = new List<int>();

        private delegate void Sort();

        private int[] _aux;
        private CancellationTokenSource _cts;
        private Task _task;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private Bitmap _bmp;

        private static void Swap(ref int i, ref int j)
        {
            var temp = i;
            i = j;
            j = temp;
        }

        private void DrawRectangles(int[] arr)
        {
            var y = pictureBox1.Height - 2;
            var x1 = 5;
            var x2 = pictureBox1.Width - 5;
            var width = 10;
            int gap = 5;
            try
            {
                using (var g = Graphics.FromImage(_bmp))
                using (var gx = pictureBox1.CreateGraphics())
                {
                    g.Clear(Color.White);
                    var pen = new Pen(Color.Black);
                    var brush = new SolidBrush(Color.Chocolate);
                    var p1 = new Point(x1, y);
                    var p2 = new Point(x2, y);

                    g.DrawLine(pen, p1, p2);
                    for (var i = 0; i < arr.Length; i++)
                    {
                        g.FillRectangle(brush, x1 + width * i + gap * i, y - arr[i], width, arr[i]);
                    }

                    gx.DrawImage(_bmp, 0, 0);
                    //Thread.Sleep(5);
                }
            }
            catch (ObjectDisposedException ode)
            {

            }
        }

        private string Dump(IEnumerable<int> a, int x = 0, int y = 0)
        {
            var sb = new StringBuilder();
            sb.Append("i=" + x);
            sb.Append("j=" + y);
            sb.Append(" ");
            foreach (int t in a)
            {
                sb.Append(t);
                sb.Append(",");
            }

            var r = sb.ToString().Substring(0, sb.Length - 1);
            r = r + Environment.NewLine;
            return r;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            _bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _cts = new CancellationTokenSource();
            //btnGetRandomArray_Click(null, null);
        }

        private int[] GetRandomArray(int size, int max)
        {
            var d = new Dictionary<int, int>();
            var r = new Random(DateTime.Now.Millisecond);
            while (d.Count < size)
            {
                var n = r.Next(max);
                if (!d.ContainsKey(n))
                {
                    d.Add(n, n);
                }
            }

            _randomArray = d.Keys.ToList();
            return new List<int>(d.Keys).ToArray();
        }

        private void btnGetRandomArray_Click(object sender, EventArgs e)
        {
            var max = pictureBox1.Height - 2;
            _arr = GetRandomArray(75, max);
            DrawRectangles(_arr);
            textBox1.Text = Dump(_arr) + Environment.NewLine;
        }

        private bool Less(int x, int y)
        {
            //Thread.Sleep(1);// 模拟比较时间消耗
            return x < y;
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            _arr = _randomArray.ToArray();
            textBox1.Text = Dump(_arr) + Environment.NewLine;
            textBox1.Refresh();
            DrawRectangles(_arr);

            var btn = sender as Button;
            Sort s = BubbleSort;
            if (btn != null)
            {
                var tag = btn.Tag.ToString();

                switch (tag)
                {
                    case "bubble":
                        s = BubbleSort;
                        break;

                    case "selection":
                        s = SelectionSort;
                        break;

                    case "insert":
                        s = InsertSort;
                        break;

                    case "shell":
                        s = ShellSort;
                        break;

                    case "merge1":
                        s = MergeSortUpToDown;
                        break;

                    case "merge2":
                        s = MergeSortDownToUp;
                        break;

                    case "quick":
                        s = QuickSort;
                        break;

                    case "quick3way":
                        s = QuickSort3Way;
                        break;

                    case "heap":
                        s = HeapSort;
                        break;
                }
            }

            _task = Task.Run(() => s());
            _task.ContinueWith(r =>
            {
                textBox1.Text = Dump(_arr) + Environment.NewLine;
                textBox1.Refresh();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void BubbleSort()
        {
            int n = _arr.Length;
            for (var i = 0; i < n; i++)
            {
                for (var j = 1; j < n - i; j++)
                {
                    if (Less(_arr[j], _arr[j - 1]))
                    {
                        Swap(ref _arr[j], ref _arr[j - 1]);
                        DrawRectangles(_arr);
                    }
                }
            }
        }

        private void SelectionSort()
        {
            int n = _arr.Length;
            for (var i = 0; i < n; i++)
            {
                int min = i;
                for (var j = i; j < n; j++)
                {
                    if (Less(_arr[j], _arr[min]))
                    {
                        min = j;
                    }
                }

                Swap(ref _arr[min], ref _arr[i]);
                DrawRectangles(_arr);
            }
        }

        private void InsertSort()
        {
            int n = _arr.Length;
            for (var i = 1; i < n; i++)
            {
                for (var j = i; j > 0 && Less(_arr[j], _arr[j - 1]); j--)
                {
                    Swap(ref _arr[j], ref _arr[j - 1]);
                    DrawRectangles(_arr);
                }
            }
        }

        private void ShellSort()
        {
            int n = _arr.Length;
            int h = 1;
            while (h < n / 3)
            {
                h = 3 * h + 1;
            }
            while (h >= 1)
            {
                for (var i = h; i < n; i++)
                {
                    for (var j = i; j >= h && Less(_arr[j], _arr[j - h]); j -= h)
                    {
                        Swap(ref _arr[j], ref _arr[j - h]);
                        DrawRectangles(_arr);
                    }
                }

                h = h / 3;
            }
        }

        private void MergeSortDownToUp()
        {
            int n = _arr.Length;
            _aux = new int[n];
            for (int sz = 1; sz < n; sz = sz + sz)
            {
                for (int lo = 0; lo < n - sz; lo += sz + sz)
                {
                    Merge(_arr, lo, lo + sz - 1, Math.Min(lo + sz + sz - 1, n - 1));
                }
            }
        }

        public void MergeSortUpToDown()
        {
            _aux = new int[_arr.Length];
            MergeSort(_arr, 0, _arr.Length - 1);
        }

        public void MergeSort(int[] a, int lo, int hi)
        {
            _aux = new int[a.Length];
            if (hi <= lo)
            {
                return;
            }

            int mid = lo + (hi - lo) / 2;
            MergeSort(a, lo, mid);
            MergeSort(a, mid + 1, hi);
            Merge(a, lo, mid, hi);
        }

        public void Merge(int[] a, int lo, int mid, int hi)
        {
            int i = lo;
            int j = mid + 1;
            for (int k = 0; k <= hi; k++)
            {
                _aux[k] = a[k];
            }

            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) a[k] = _aux[j++];
                else if (j > hi) a[k] = _aux[i++];
                else if (Less(_aux[j], _aux[i])) a[k] = _aux[j++];
                else a[k] = _aux[i++];
            }

            DrawRectangles(_arr);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_task!= null && !_task.IsCompleted)
            {
                e.Cancel = true;
                _cts.Cancel();
            }

            e.Cancel = false;
        }

        public void QuickSort()
        {
            new Random().Shuffle(_arr);
            QuickSort(_arr, 0, _arr.Length - 1);
        }

        public void QuickSort(int[] a, int lo, int hi)
        {
            if (hi <= lo) return;
            int j = Partition(a, lo, hi);
            QuickSort(a, lo, j - 1);
            QuickSort(a, j + 1, hi);
        }

        private int Partition(int[] a, int lo, int hi)
        {
            int i = lo, j = hi + 1;
            int v = a[lo];
            while (true)
            {
                while (Less(a[++i], v)) if (i == hi) break;
                while (Less(v, a[--j])) if (j == lo) break;
                if (i >= j) break;
                Swap(ref a[i], ref a[j]);
                DrawRectangles(_arr);
            }

            Swap(ref a[lo], ref a[j]);
            DrawRectangles(_arr);

            return j;
        }

        public void QuickSort3Way()
        {
            new Random().Shuffle(_arr);
            QuickSort3Way(_arr, 0, _arr.Length - 1);
        }

        public void QuickSort3Way(int[] a, int lo, int hi)
        {
            if (hi <= lo) return;
            int lt = lo, i = lo + 1, gt = hi;
            var v = a[lo];
            while (i <= gt)
            {
                int cmp = a[i].CompareTo(v);
                if (cmp < 0)
                {
                    Swap(ref a[lt++], ref a[i++]);
                    DrawRectangles(_arr);
                }
                else if (cmp > 0)
                {
                    Swap(ref a[i], ref a[gt--]);
                    DrawRectangles(_arr);
                }

                else i++;
            }

            QuickSort3Way(a, lo, lt - 1);
            QuickSort3Way(a, gt + 1, hi);
        }

        public void HeapSort()
        {
            var length = _arr.Length;
            for (int i = length / 2 - 1; i >= 0; i--)
            {
                Heapify(_arr, length, i);
            }

            for (int i = length - 1; i >= 0; i--)
            {
                Swap(ref _arr[0], ref _arr[i]);
                DrawRectangles(_arr);
                Heapify(_arr, i, 0);
            }
        }

        private static void Heapify(int[] array, int length, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < length && array[left] > array[largest])
            {
                largest = left;
            }
            if (right < length && array[right] > array[largest])
            {
                largest = right;
            }
            if (largest != i)
            {
                int swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;
                Heapify(array, length, largest);
            }
        }
    }

    internal static class RandomExtensions
    {
        public static void Shuffle<T>(this Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}