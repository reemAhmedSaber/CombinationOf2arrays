using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CombinationOf2arrays
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<string> get_combinaton(string[]x,string[]y)
        {
            int N = x.Length;
            string[]return_arr=new string[N];
            string[] com_arr1 = new string[(int)Math.Pow(2,N)/2];
            string[] com_arr2 = new string[(int)Math.Pow(2, N) / 2];
            List<string> combination_arr = new List<string>();
            for(int i=0;i<Math.Pow(2,N)/2;i++)
            {
                com_arr1[i]="";
                com_arr2[i]="";
            }
            for (int i = 0; i < N;i++ )
            {
                int count = 0;
                for(int k=0;k<Math.Pow(2,i);k++)
                {
                    for(int j=0;j<(Math.Pow(2,(N-1-i)));j++)
                    {
                        if(i==0)
                        {
                            com_arr1[count] += x[i];
                            com_arr2[count] += y[i];
                        }
                        else
                        {
                            if(k%2==0)
                            {
                                com_arr1[count] += " "+x[i];
                                com_arr2[count] += " "+x[i];
                            }
                            else if (k % 2 != 0)
                            {
                                com_arr1[count] += " "+y[i];
                                com_arr2[count] += " "+y[i];
                            }
                        }
                        count++;
                    }
                }
            }
            for (int i = 0; i < com_arr1.Length;i++ )
            {
                combination_arr.Add(com_arr1[i]);
            }
            for (int i = 0; i < com_arr2.Length; i++)
            {
                combination_arr.Add(com_arr2[i]);
            }

            return combination_arr;

        }
        public string[] separators(string s)
        {
            string[] separators = { ",", ".", "!", "?", ";", ":", " ", "\n" };
            string[] words = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> arr;
            string[] text1;
            string[] text2;
            text1 = separators(textBox1.Text);
            text2 = separators(textBox2.Text);
            arr = get_combinaton(text1,text2);
            System.IO.File.WriteAllLines(@"E:\task2\CombinationWords.txt", arr);
            //for (int i = 0; i < arr.Count; i++)
            //    MessageBox.Show(arr[i]);
        }
    }
}
