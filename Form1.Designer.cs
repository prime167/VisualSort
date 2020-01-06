namespace VisualSort
{
    sealed partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_BubbleSort = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnGetRandomArray = new System.Windows.Forms.Button();
            this.btnSelectionSort = new System.Windows.Forms.Button();
            this.btn_InsertSort = new System.Windows.Forms.Button();
            this.btn_ShellSort = new System.Windows.Forms.Button();
            this.btn_MergeSort = new System.Windows.Forms.Button();
            this.btn_MergeSort1 = new System.Windows.Forms.Button();
            this.btn_QuickSort = new System.Windows.Forms.Button();
            this.btn_Quick3Way = new System.Windows.Forms.Button();
            this.btn_HeapSort = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_BubbleSort
            // 
            this.btn_BubbleSort.Location = new System.Drawing.Point(157, 12);
            this.btn_BubbleSort.Name = "btn_BubbleSort";
            this.btn_BubbleSort.Size = new System.Drawing.Size(75, 23);
            this.btn_BubbleSort.TabIndex = 0;
            this.btn_BubbleSort.Tag = "bubble";
            this.btn_BubbleSort.Text = "冒泡排序";
            this.btn_BubbleSort.UseVisualStyleBackColor = true;
            this.btn_BubbleSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(12, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1127, 302);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 420);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(1138, 88);
            this.textBox1.TabIndex = 2;
            // 
            // btnGetRandomArray
            // 
            this.btnGetRandomArray.Location = new System.Drawing.Point(37, 12);
            this.btnGetRandomArray.Name = "btnGetRandomArray";
            this.btnGetRandomArray.Size = new System.Drawing.Size(97, 23);
            this.btnGetRandomArray.TabIndex = 3;
            this.btnGetRandomArray.Text = "生成随机数组";
            this.btnGetRandomArray.UseVisualStyleBackColor = true;
            this.btnGetRandomArray.Click += new System.EventHandler(this.btnGetRandomArray_Click);
            // 
            // btnSelectionSort
            // 
            this.btnSelectionSort.Location = new System.Drawing.Point(256, 12);
            this.btnSelectionSort.Name = "btnSelectionSort";
            this.btnSelectionSort.Size = new System.Drawing.Size(75, 23);
            this.btnSelectionSort.TabIndex = 4;
            this.btnSelectionSort.Tag = "selection";
            this.btnSelectionSort.Text = "选择排序";
            this.btnSelectionSort.UseVisualStyleBackColor = true;
            this.btnSelectionSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btn_InsertSort
            // 
            this.btn_InsertSort.Location = new System.Drawing.Point(351, 12);
            this.btn_InsertSort.Name = "btn_InsertSort";
            this.btn_InsertSort.Size = new System.Drawing.Size(75, 23);
            this.btn_InsertSort.TabIndex = 5;
            this.btn_InsertSort.Tag = "insert";
            this.btn_InsertSort.Text = "插入排序";
            this.btn_InsertSort.UseVisualStyleBackColor = true;
            this.btn_InsertSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btn_ShellSort
            // 
            this.btn_ShellSort.Location = new System.Drawing.Point(441, 12);
            this.btn_ShellSort.Name = "btn_ShellSort";
            this.btn_ShellSort.Size = new System.Drawing.Size(75, 23);
            this.btn_ShellSort.TabIndex = 6;
            this.btn_ShellSort.Tag = "shell";
            this.btn_ShellSort.Text = "希尔排序";
            this.btn_ShellSort.UseVisualStyleBackColor = true;
            this.btn_ShellSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btn_MergeSort
            // 
            this.btn_MergeSort.Location = new System.Drawing.Point(535, 12);
            this.btn_MergeSort.Name = "btn_MergeSort";
            this.btn_MergeSort.Size = new System.Drawing.Size(130, 23);
            this.btn_MergeSort.TabIndex = 7;
            this.btn_MergeSort.Tag = "merge1";
            this.btn_MergeSort.Text = "归并排序(自顶向下)";
            this.btn_MergeSort.UseVisualStyleBackColor = true;
            this.btn_MergeSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btn_MergeSort1
            // 
            this.btn_MergeSort1.Location = new System.Drawing.Point(682, 12);
            this.btn_MergeSort1.Name = "btn_MergeSort1";
            this.btn_MergeSort1.Size = new System.Drawing.Size(130, 23);
            this.btn_MergeSort1.TabIndex = 8;
            this.btn_MergeSort1.Tag = "merge2";
            this.btn_MergeSort1.Text = "归并排序(自底向上)";
            this.btn_MergeSort1.UseVisualStyleBackColor = true;
            this.btn_MergeSort1.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btn_QuickSort
            // 
            this.btn_QuickSort.Location = new System.Drawing.Point(832, 12);
            this.btn_QuickSort.Name = "btn_QuickSort";
            this.btn_QuickSort.Size = new System.Drawing.Size(130, 23);
            this.btn_QuickSort.TabIndex = 9;
            this.btn_QuickSort.Tag = "quick";
            this.btn_QuickSort.Text = " 快速排序";
            this.btn_QuickSort.UseVisualStyleBackColor = true;
            this.btn_QuickSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btn_Quick3Way
            // 
            this.btn_Quick3Way.Location = new System.Drawing.Point(968, 12);
            this.btn_Quick3Way.Name = "btn_Quick3Way";
            this.btn_Quick3Way.Size = new System.Drawing.Size(130, 23);
            this.btn_Quick3Way.TabIndex = 10;
            this.btn_Quick3Way.Tag = "quick3way";
            this.btn_Quick3Way.Text = " 快速排序(三向切分)";
            this.btn_Quick3Way.UseVisualStyleBackColor = true;
            this.btn_Quick3Way.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btn_HeapSort
            // 
            this.btn_HeapSort.Location = new System.Drawing.Point(157, 47);
            this.btn_HeapSort.Name = "btn_HeapSort";
            this.btn_HeapSort.Size = new System.Drawing.Size(75, 23);
            this.btn_HeapSort.TabIndex = 11;
            this.btn_HeapSort.Tag = "heap";
            this.btn_HeapSort.Text = "堆排序";
            this.btn_HeapSort.UseVisualStyleBackColor = true;
            this.btn_HeapSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 614);
            this.Controls.Add(this.btn_HeapSort);
            this.Controls.Add(this.btn_Quick3Way);
            this.Controls.Add(this.btn_QuickSort);
            this.Controls.Add(this.btn_MergeSort1);
            this.Controls.Add(this.btn_MergeSort);
            this.Controls.Add(this.btn_ShellSort);
            this.Controls.Add(this.btn_InsertSort);
            this.Controls.Add(this.btnSelectionSort);
            this.Controls.Add(this.btnGetRandomArray);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_BubbleSort);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_BubbleSort;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnGetRandomArray;
        private System.Windows.Forms.Button btnSelectionSort;
        private System.Windows.Forms.Button btn_InsertSort;
        private System.Windows.Forms.Button btn_ShellSort;
        private System.Windows.Forms.Button btn_MergeSort;
        private System.Windows.Forms.Button btn_MergeSort1;
        private System.Windows.Forms.Button btn_QuickSort;
        private System.Windows.Forms.Button btn_Quick3Way;
        private System.Windows.Forms.Button btn_HeapSort;
    }
}

