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
            //0.��ť������״̬
            if (btnStartOrEnd.Text == "��ʼ")
            {
                //1.�ж��Ƿ��мƻ�����
                if (txtPlanContent.Text.Trim().Length > 0)
                {
                    btnStartOrEnd.Text = "ֹͣ";

                    //2.������ʼ����ʱ��
                    txtStartTime.Text = DateTime.Now.ToString();
                    txtEndTime.Text = DateTime.Now.AddMinutes(30).ToString();

                    //3.����ʱ��ʼ
                    timer1.Enabled = true;

                }
                else
                {
                    MessageBox.Show("������д�ֽ׶μƻ����ݣ�");
                }
            }
            else if (btnStartOrEnd.Text == "ֹͣ")
            {
                if (txtPlanContent.Text.Trim().Length==0)
                {
                    MessageBox.Show("������д��ֹԭ��");
                    return ;
                }

                DialogResult dr = MessageBox.Show("��ȷ����ֹ��", "�ټ��һ�£�", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    //��ֹ
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

                            lblDayCount.Text = $"�ɹ�{newCount.SuccessItems.Count}�Σ�ʧ��{newCount.FailedItems.Count}��";
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

                            lblDayCount.Text = $"�ɹ�{dayCount.SuccessItems.Count}�Σ�ʧ��{dayCount.FailedItems.Count}��";

                        }

                        //���һ�����ں������
                        btnStartOrEnd.Text = "��ʼ";
                        txtDoneContent.Text = "";
                        txtEndTime.Text = "";
                        txtPlanContent.Text = "";
                        txtStartTime.Text = "";
                        lblSurplusTime.Text = "";
                        //���¼���DataGridView
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

        //��ʱ���¼�
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
                    lblSurplusTime.Text = $"{timeRemain.Minutes}����{timeRemain.Seconds}��";
                }
                else
                {
                   timer1.Enabled = false;
                    
                    //���һ�����ڡ����ݱ��������ݿ��С�
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

                            lblDayCount.Text = $"�ɹ�{newCount.SuccessItems.Count}�Σ�ʧ��{newCount.FailedItems.Count}��";
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

                            lblDayCount.Text = $"�ɹ�{dayCount.SuccessItems.Count}�Σ�ʧ��{dayCount.FailedItems.Count}��";
                        }

                        //���һ�����ں������
                        btnStartOrEnd.Text = "��ʼ";
                        txtDoneContent.Text = "";
                        txtEndTime.Text = "";
                        txtPlanContent.Text = "";
                        txtStartTime.Text = "";
                        lblSurplusTime.Text = "";
                        //���¼���DataGridView
                        LoadDbInfo();

                    }

                    //MessageBox.Show("��ϲ�����һ�����ڣ�����Ϣ5-10���Ӽ�����");

                    MessageBox.Show("��ϲ�����һ�����ڣ�����Ϣ5-10���Ӽ�����", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

                }
            }
        }


        //��ȡ���ݵļ�¼
        private void LoadDbInfo()
        {
            //1.�����ݿ��л�ȡ����ͳ��
            using (var context = new MyDbContext())
            {
                string nowTime = DateTime.Now.ToString("yyyy-MM-dd");
                var dayCount = context.DayCounts.Include(d => d.SuccessItems).Include(d => d.FailedItems).FirstOrDefault(d => d.Date == nowTime);
                if (dayCount == null)
                {
                    lblDayCount.Text = $"����δ��ʼ��";
                }
                else
                {
                    lblDayCount.Text = $"�ɹ�{dayCount.SuccessItems.Count}�Σ�ʧ��{dayCount.FailedItems.Count}��";
                }

                //չʾ�ѳɹ�����
                dataGridView1.DataSource = context.SuccessItems.OrderByDescending(s=>s.CreateTime).Select(s => new { s.Id, CreateTime = s.CreateTime.ToString("yyyy-MM-dd"), StartTime = s.StartDateTime.Substring(s.StartDateTime.IndexOf(' ')), EndTime = s.EndDateTime.Substring(s.EndDateTime.IndexOf(' ')), s.PlanContent }).ToList();//.OrderByDescending(w => w.Id);

                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }
        }


    }
}