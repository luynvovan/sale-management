namespace GUI
{
    partial class ShowOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.idCus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cusName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cusPhone = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.orderAddress = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.userId = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dateOrder = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dateComplete = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dgvOrderDetail = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.total = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.discount_percent = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.usedPoint = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lastPrice = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.addPoint = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.discount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetail)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.status);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.dateComplete);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.dateOrder);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.userName);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.userId);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.orderAddress);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cusPhone);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cusName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.idCus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1042, 208);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // idCus
            // 
            this.idCus.AutoSize = true;
            this.idCus.Location = new System.Drawing.Point(172, 38);
            this.idCus.Name = "idCus";
            this.idCus.Size = new System.Drawing.Size(61, 18);
            this.idCus.TabIndex = 11;
            this.idCus.Text = "label16";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "ID KH:";
            // 
            // cusName
            // 
            this.cusName.AutoSize = true;
            this.cusName.Location = new System.Drawing.Point(172, 69);
            this.cusName.Name = "cusName";
            this.cusName.Size = new System.Drawing.Size(61, 18);
            this.cusName.TabIndex = 13;
            this.cusName.Text = "label16";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tên:";
            // 
            // cusPhone
            // 
            this.cusPhone.AutoSize = true;
            this.cusPhone.Location = new System.Drawing.Point(172, 101);
            this.cusPhone.Name = "cusPhone";
            this.cusPhone.Size = new System.Drawing.Size(61, 18);
            this.cusPhone.TabIndex = 15;
            this.cusPhone.Text = "label16";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "SĐT:";
            // 
            // orderAddress
            // 
            this.orderAddress.AutoSize = true;
            this.orderAddress.Location = new System.Drawing.Point(172, 133);
            this.orderAddress.Name = "orderAddress";
            this.orderAddress.Size = new System.Drawing.Size(61, 18);
            this.orderAddress.TabIndex = 17;
            this.orderAddress.Text = "label16";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(92, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 18);
            this.label7.TabIndex = 16;
            this.label7.Text = "Địa chỉ:";
            // 
            // userId
            // 
            this.userId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userId.AutoSize = true;
            this.userId.Location = new System.Drawing.Point(784, 38);
            this.userId.Name = "userId";
            this.userId.Size = new System.Drawing.Size(61, 18);
            this.userId.TabIndex = 19;
            this.userId.Text = "label16";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(681, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 18);
            this.label9.TabIndex = 18;
            this.label9.Text = "ID NV:";
            // 
            // userName
            // 
            this.userName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userName.AutoSize = true;
            this.userName.Location = new System.Drawing.Point(784, 69);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(61, 18);
            this.userName.TabIndex = 21;
            this.userName.Text = "label16";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(681, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 18);
            this.label11.TabIndex = 20;
            this.label11.Text = "Tên:";
            // 
            // dateOrder
            // 
            this.dateOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateOrder.AutoSize = true;
            this.dateOrder.Location = new System.Drawing.Point(784, 101);
            this.dateOrder.Name = "dateOrder";
            this.dateOrder.Size = new System.Drawing.Size(61, 18);
            this.dateOrder.TabIndex = 23;
            this.dateOrder.Text = "label16";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(681, 101);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 18);
            this.label13.TabIndex = 22;
            this.label13.Text = "Ngày đặt:";
            // 
            // dateComplete
            // 
            this.dateComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateComplete.AutoSize = true;
            this.dateComplete.Location = new System.Drawing.Point(784, 133);
            this.dateComplete.Name = "dateComplete";
            this.dateComplete.Size = new System.Drawing.Size(61, 18);
            this.dateComplete.TabIndex = 25;
            this.dateComplete.Text = "label16";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(681, 133);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 18);
            this.label15.TabIndex = 24;
            this.label15.Text = "Ngày xong:";
            // 
            // status
            // 
            this.status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(784, 168);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(61, 18);
            this.status.TabIndex = 27;
            this.status.Text = "label16";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(681, 168);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 18);
            this.label17.TabIndex = 26;
            this.label17.Text = "Trạng thái:";
            // 
            // dgvOrderDetail
            // 
            this.dgvOrderDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderDetail.Location = new System.Drawing.Point(13, 227);
            this.dgvOrderDetail.Name = "dgvOrderDetail";
            this.dgvOrderDetail.ReadOnly = true;
            this.dgvOrderDetail.RowHeadersWidth = 62;
            this.dgvOrderDetail.RowTemplate.Height = 27;
            this.dgvOrderDetail.Size = new System.Drawing.Size(1042, 152);
            this.dgvOrderDetail.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.discount);
            this.groupBox2.Controls.Add(this.lastPrice);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.usedPoint);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.discount_percent);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.total);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Location = new System.Drawing.Point(555, 400);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(500, 211);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thành tiền";
            // 
            // total
            // 
            this.total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.total.AutoSize = true;
            this.total.Location = new System.Drawing.Point(298, 51);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(61, 18);
            this.total.TabIndex = 29;
            this.total.Text = "label18";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(39, 51);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 18);
            this.label19.TabIndex = 28;
            this.label19.Text = "Tổng:";
            // 
            // discount_percent
            // 
            this.discount_percent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.discount_percent.AutoSize = true;
            this.discount_percent.Location = new System.Drawing.Point(167, 91);
            this.discount_percent.Name = "discount_percent";
            this.discount_percent.Size = new System.Drawing.Size(61, 18);
            this.discount_percent.TabIndex = 31;
            this.discount_percent.Text = "label20";
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(39, 91);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 18);
            this.label21.TabIndex = 30;
            this.label21.Text = "Giảm giá";
            // 
            // usedPoint
            // 
            this.usedPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usedPoint.AutoSize = true;
            this.usedPoint.Location = new System.Drawing.Point(298, 133);
            this.usedPoint.Name = "usedPoint";
            this.usedPoint.Size = new System.Drawing.Size(61, 18);
            this.usedPoint.TabIndex = 33;
            this.usedPoint.Text = "label22";
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(39, 133);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(90, 18);
            this.label23.TabIndex = 32;
            this.label23.Text = "Dùng điểm:";
            // 
            // lastPrice
            // 
            this.lastPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lastPrice.AutoSize = true;
            this.lastPrice.Location = new System.Drawing.Point(298, 173);
            this.lastPrice.Name = "lastPrice";
            this.lastPrice.Size = new System.Drawing.Size(61, 18);
            this.lastPrice.TabIndex = 35;
            this.lastPrice.Text = "label24";
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(39, 173);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(91, 18);
            this.label25.TabIndex = 34;
            this.label25.Text = "Thành tiền:";
            // 
            // addPoint
            // 
            this.addPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addPoint.AutoSize = true;
            this.addPoint.Location = new System.Drawing.Point(243, 400);
            this.addPoint.Name = "addPoint";
            this.addPoint.Size = new System.Drawing.Size(61, 18);
            this.addPoint.TabIndex = 37;
            this.addPoint.Text = "label26";
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(12, 400);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(197, 18);
            this.label27.TabIndex = 36;
            this.label27.Text = "Điểm tích khi hoàn thành:";
            // 
            // discount
            // 
            this.discount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.discount.AutoSize = true;
            this.discount.Location = new System.Drawing.Point(298, 91);
            this.discount.Name = "discount";
            this.discount.Size = new System.Drawing.Size(61, 18);
            this.discount.TabIndex = 36;
            this.discount.Text = "label20";
            // 
            // ShowOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 622);
            this.Controls.Add(this.addPoint);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.dgvOrderDetail);
            this.Controls.Add(this.groupBox1);
            this.Name = "ShowOrder";
            this.Text = "ShowOrder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetail)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label dateComplete;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label dateOrder;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label userId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label orderAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label cusPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label cusName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label idCus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvOrderDetail;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lastPrice;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label usedPoint;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label discount_percent;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label addPoint;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label discount;
    }
}