﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KDM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mtbase = new MeiTuan();
            var offset = 0;
            var datas = new List<Poiinfo>();
            var r = mtbase.MobileGetDatas(offset);
            datas.AddRange(r.data.poiList.poiInfos);
            var total = r.data.poiList.totalCount;
            var pages = total / 15 + (total % 15 == 0 ? 0 : 1);

            var t = Task.Run(() =>
              {
                  for (int i = 1; i < pages; i++)
                  {
                      datas.AddRange(mtbase.MobileGetDatas(i * 15).data.poiList.poiInfos);
                  }
              });
            Task.Factory.StartNew(() =>
            {
                Task.WaitAll(t);
                this.Invoke((MethodInvoker)delegate
                {
                    var dt = CreateTable();
                    datas.ForEach(n =>
                    {
                        var dr = dt.NewRow();
                        dr["系统编号"] = n.poiid;
                        dr["店铺名称"] = n.name;
                        dr["所在区域"] = n.areaName;
                        dr["产品大类"] = n.channel;
                        dr["产品细类"] = n.cateName;
                        dr["人均消费"] = n.avgPrice;
                        dr["店铺评分"] = n.avgScore;
                        dr["纬度"] = n.lat;
                        dr["经度"] = n.lng;
                        dr["卖点"] = string.Join(";", n.preferentialInfo.maidan.entries.Select(s => s.content));
                        dr["店铺图片"] = n.frontImg;
                        dr["评价"] = string.Join(";", n.smartTags.Select(s => s.text.content));
                        dt.Rows.Add(dr);
                    });
                    dataGridView1.DataSource = dt;
                });
            });
        }
        DataTable CreateTable()
        {
            var dt = new DataTable();
            dt.Columns.Add("系统编号");
            dt.Columns.Add("店铺名称");
            dt.Columns.Add("所在区域");
            dt.Columns.Add("产品大类");
            dt.Columns.Add("产品细类");
            dt.Columns.Add("人均消费", typeof(decimal));
            dt.Columns.Add("店铺评分", typeof(decimal));
            dt.Columns.Add("纬度");
            dt.Columns.Add("经度");
            dt.Columns.Add("卖点");
            dt.Columns.Add("店铺图片");
            dt.Columns.Add("评价");
            return dt;
        }


        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dataGridView1.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dataGridView1.RowHeadersDefaultCellStyle.Font, rectangle, dataGridView1.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog kk = new SaveFileDialog();
            kk.Title = "保存EXCEL文件";
            kk.Filter = "excel文件(*.xlsx) |*.xlsx ";
            kk.FilterIndex = 1;
            if (kk.ShowDialog() == DialogResult.OK)
            {
                var tk = Task<bool>.Factory.StartNew(() =>
                {
                    //var dt = dataGridView1.DataSource as List<Poiinfo>;
                    //return EppHelper.ExportByModel(kk.FileName, dt);
                    //var dt = dataGridView1.DataSource as DataTable;
                    //return EppHelper.ExportByDt(kk.FileName, dt);
                    return EppHelper.ExportByModel<WebPoiinfo>(kk.FileName, datas);
                });
                Task.Factory.StartNew(() =>
                {
                    Task.WaitAll(tk);
                    if (tk.Result)
                    {
                        MessageBox.Show("保存Excel成功");
                    }
                });
            }
        }
        List<WebPoiinfo> datas = new List<WebPoiinfo>();
        private void button3_Click(object sender, EventArgs e)
        {
            var mtbase = new MeiTuan();
            //var datas = new List<WebPoiinfo>();
            var r = mtbase.WebGetDatas("1");
            richTextBox1.Text += "正在获取第1页\r\n";
            datas.AddRange(r.data.poiInfos);
            var tasklst = new List<Task>();
            var pages = r.data.totalCounts / 7 + (r.data.totalCounts % 7 == 0 ? 0 : 1);
            if (pages > 1)
            {
                var t = Task.Run(() =>
                {
                    for (int i = 2; i < pages; i++)
                    {
                        datas.AddRange(mtbase.WebGetDatas(i.ToString()).data.poiInfos);
                        this.Invoke((MethodInvoker)delegate
                        {
                            richTextBox1.Text += $"正在获取第{i}页\r\n";
                        });
                    }
                });
                tasklst.Add(t);
            }
            Task.Run(() =>
            {
                Task.WaitAll(tasklst.ToArray());
                this.Invoke((MethodInvoker)delegate
                {
                    dataGridView1.DataSource = datas;
                    richTextBox1.Text += "基础数据获取完毕，开始获取店铺联系方式\r\n";
                });
            });
        }
        public void GetPhone()
        {
            var mtbase = new MeiTuan();
            var tasklst = new List<Task>();
            var t = Task.Run(() =>
            {
                datas.ForEach(n =>
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        richTextBox1.Text += $"正在获取“{n.title}”的店铺联系方式，店铺ID为{n.poiId}\r\n";
                    });
                    n.dh = mtbase.GetDetail(n.poiId.ToString());
                });
            });
            tasklst.Add(t);
            Task.Run(() =>
            {
                Task.WaitAll(tasklst.ToArray());
                this.Invoke((MethodInvoker)delegate
                {
                    dataGridView1.DataSource = datas;
                    richTextBox1.Text += "数据获取完毕";
                });
            });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var mt = new MeiTuan();
            var s = mt.GetDetail();
            richTextBox1.Text = s;
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GetPhone();
        }
    }
}
