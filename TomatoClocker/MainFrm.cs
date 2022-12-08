using Microsoft.EntityFrameworkCore;
using TomatoClocker.Models;

namespace TomatoClocker
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }


        private void btnStartOrEnd_Click(object sender, EventArgs e)
        {
            //0.按钮的两种状态
            if (btnStartOrEnd.Text == "开始")
            {
                //1.判断是否有计划事宜
                if (txtPlanContent.Text.Trim().Length > 0)
                {
                    btnStartOrEnd.Text = "停止";

                    //2.计算起始结束时间
                    txtStartTime.Text = DateTime.Now.ToString();
                    txtEndTime.Text = DateTime.Now.AddMinutes(30).ToString();

                    //3.倒计时开始
                    timer1.Enabled = true;

                }
                else
                {
                    MessageBox.Show("请先填写现阶段计划内容！");
                }
            }
            else if (btnStartOrEnd.Text == "停止")
            {
                if (txtPlanContent.Text.Trim().Length==0)
                {
                    MessageBox.Show("请先填写终止原因！");
                    return ;
                }

                DialogResult dr = MessageBox.Show("你确定终止吗？", "再坚持一下！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    //终止
                    timer1.Enabled=false;

                    using (var context=new MyDbContext())
                    {
                        string nowTime = DateTime.Now.ToString("yyyy-MM-dd");
                        DayCount? dayCount = context.DayCounts.Include(d => d.SuccessItems).Include(d => d.FailedItems).FirstOrDefault(d => d.Date == nowTime);
                        if (dayCount == null)
                        {
                            FailedItem item = new FailedItem()
                            {
                                ContinuousTime = Math.Round((DateTime.Now-Convert.ToDateTime(txtStartTime.Text)).TotalMinutes,2),
                                FailedReason = txtDoneContent.Text,
                                PlanContent = txtPlanContent.Text,
                                StartDateTime = txtStartTime.Text,
                                EndDateTime = DateTime.Now.ToString(),
                                Remark = "",
                                CreateTime = DateTime.Now
                            };

                            DayCount newCount = new DayCount()
                            {
                                Count = 0,
                                Date = DateTime.Now.ToString("yyyy-MM-dd"),
                                CreateTime = DateTime.Now

                            };
                            newCount.FailedItems.Add(item);

                            context.DayCounts.Add(newCount);

                            context.SaveChanges();

                            lblDayCount.Text = $"成功{newCount.SuccessItems.Count}次，失败{newCount.FailedItems.Count}次";
                        }
                        else
                        {
                            FailedItem item = new FailedItem()
                            {
                                ContinuousTime =Math.Round( (DateTime.Now - Convert.ToDateTime(txtStartTime.Text)).TotalMinutes,2),
                                FailedReason = txtDoneContent.Text,
                                PlanContent = txtPlanContent.Text,
                                StartDateTime = txtStartTime.Text,
                                EndDateTime = txtEndTime.Text,
                                Remark = "",
                                CreateTime = DateTime.Now

                            };
                            dayCount.FailedItems.Add(item);

                            context.SaveChanges();

                            lblDayCount.Text = $"成功{dayCount.SuccessItems.Count}次，失败{dayCount.FailedItems.Count}次";

                        }

                        //完成一个周期后的清理
                        btnStartOrEnd.Text = "开始";
                        txtDoneContent.Text = "";
                        txtEndTime.Text = "";
                        txtPlanContent.Text = "";
                        txtStartTime.Text = "";
                        lblSurplusTime.Text = "";
                        //重新加载DataGridView
                        LoadDbInfo();


                    }

                }
            }




        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            LoadDbInfo();
        }

        //定时器事件
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txtEndTime.Text.Length > 0)
            {
                DateTime endTime = Convert.ToDateTime(txtEndTime.Text);
                DateTime startTime = Convert.ToDateTime(txtStartTime.Text);

                TimeSpan timeRemain = endTime - DateTime.Now;
                TimeSpan timeDone=DateTime.Now - startTime;
                TimeSpan totalSpan=endTime - startTime;

                TaskbarManager.SetProgressValue(totalSpan.Minutes-timeRemain.Minutes, totalSpan.Minutes);

                if (totalSpan.Minutes - timeRemain.Minutes== totalSpan.Minutes)
                {
                    TaskbarManager.SetProgressState(TaskbarProgressBarState.NoProgress);
                }


                if (endTime >= DateTime.Now)
                {
                    
                    lblSurplusTime.ForeColor = Color.Green;
                    lblSurplusTime.Text = $"{timeRemain.Minutes}分钟{timeRemain.Seconds}秒";
                }
                else
                {
                   timer1.Enabled = false;
                    
                    //完成一个周期。数据保存至数据库中。
                    using (var context = new MyDbContext())
                    {
                        string nowTime = DateTime.Now.ToString("yyyy-MM-dd");
                        DayCount? dayCount = context.DayCounts.Include(d => d.SuccessItems).Include(d => d.FailedItems).FirstOrDefault(d => d.Date == nowTime);
                        if (dayCount == null)
                        {
                            SuccessItem item = new SuccessItem()
                            {
                                ContinuousTime=Math.Round(timeDone.TotalMinutes,2),
                                DoContent=txtDoneContent.Text,
                                PlanContent=txtPlanContent.Text,
                                StartDateTime=txtStartTime.Text,
                                EndDateTime=txtEndTime.Text,
                                Remark="",
                                CreateTime = DateTime.Now

                            };

                            DayCount newCount = new DayCount()
                            {
                                Count = 1,
                                Date = DateTime.Now.ToString("yyyy-MM-dd"),
                                CreateTime = DateTime.Now

                            };
                            newCount.SuccessItems.Add(item);

                            context.DayCounts.Add(newCount);

                            context.SaveChanges();

                            lblDayCount.Text = $"成功{newCount.SuccessItems.Count}次，失败{newCount.FailedItems.Count}次";
                        }
                        else
                        {
                            SuccessItem item = new SuccessItem()
                            {
                                ContinuousTime = Math.Round(timeDone.TotalMinutes,2),
                                DoContent = txtDoneContent.Text,
                                PlanContent = txtPlanContent.Text,
                                StartDateTime = txtStartTime.Text,
                                EndDateTime = txtEndTime.Text,
                                Remark = "",
                                CreateTime = DateTime.Now
                            };
                            dayCount.Count++;
                            dayCount.SuccessItems.Add(item);

                            context.SaveChanges();

                            lblDayCount.Text = $"成功{dayCount.SuccessItems.Count}次，失败{dayCount.FailedItems.Count}次";
                        }

                        //完成一个周期后的清理
                        btnStartOrEnd.Text = "开始";
                        txtDoneContent.Text = "";
                        txtEndTime.Text = "";
                        txtPlanContent.Text = "";
                        txtStartTime.Text = "";
                        lblSurplusTime.Text = "";
                        //重新加载DataGridView
                        LoadDbInfo();

                    }

                    //MessageBox.Show("恭喜你完成一个周期！请休息5-10分钟继续！");

                    MessageBox.Show("恭喜你完成一个周期！请休息5-10分钟继续！", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

                }
            }
        }


        //读取数据的记录
        private void LoadDbInfo()
        {
            //1.从数据库中获取当日统计
            using (var context = new MyDbContext())
            {
                string nowTime = DateTime.Now.ToString("yyyy-MM-dd");
                var dayCount = context.DayCounts.Include(d => d.SuccessItems).Include(d => d.FailedItems).FirstOrDefault(d => d.Date == nowTime);
                if (dayCount == null)
                {
                    lblDayCount.Text = $"今日未开始！";
                }
                else
                {
                    lblDayCount.Text = $"成功{dayCount.SuccessItems.Count}次，失败{dayCount.FailedItems.Count}次";
                }

                //展示已成功案例
                dataGridView1.DataSource = context.SuccessItems.OrderByDescending(s=>s.CreateTime).Select(s => new { s.Id, CreateTime = s.CreateTime.ToString("yyyy-MM-dd"), StartTime = s.StartDateTime.Substring(s.StartDateTime.IndexOf(' ')), EndTime = s.EndDateTime.Substring(s.EndDateTime.IndexOf(' ')), s.PlanContent }).ToList();//.OrderByDescending(w => w.Id);

                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }
        }


    }
}