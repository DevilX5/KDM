using System;
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
            var datas =new List<Poiinfo>();
            var r = mtbase.GetDatas(offset);
            datas.AddRange(r.data.poiList.poiInfos);
            var total = r.data.poiList.totalCount;
            var pages = total/15+(total % 15==0?0:1);

            var t=Task.Run(() =>
            {
                for (int i = 1; i < pages; i++)
                {
                    datas.AddRange(mtbase.GetDatas(i * 15).data.poiList.poiInfos);
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
            dt.Columns.Add("人均消费",typeof(decimal));
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
                    var dt = dataGridView1.DataSource as DataTable;
                    return EppHelper.ExportByDt(kk.FileName, dt);
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
    }
}
