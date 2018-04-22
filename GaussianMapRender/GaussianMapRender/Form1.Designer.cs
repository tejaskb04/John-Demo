﻿namespace GaussianMapRender
{
    partial class Form1
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
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.SaveMap = new System.Windows.Forms.Button();
            this.openDialog_button = new System.Windows.Forms.Button();
            this.zoomplus_btn = new System.Windows.Forms.Button();
            this.zoomminus_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gmap
            // 
            this.gmap.AutoSize = true;
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(118, 7);
            this.gmap.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 18;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomEnabled = true;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(713, 492);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 13D;
            this.gmap.Load += new System.EventHandler(this.gmap_Load);
            // 
            // SaveMap
            // 
            this.SaveMap.Location = new System.Drawing.Point(6, 7);
            this.SaveMap.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SaveMap.Name = "SaveMap";
            this.SaveMap.Size = new System.Drawing.Size(80, 28);
            this.SaveMap.TabIndex = 1;
            this.SaveMap.Text = "Save Map";
            this.SaveMap.UseVisualStyleBackColor = true;
            this.SaveMap.Click += new System.EventHandler(this.SaveMap_Click);
            // 
            // openDialog_button
            // 
            this.openDialog_button.Location = new System.Drawing.Point(6, 40);
            this.openDialog_button.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.openDialog_button.Name = "openDialog_button";
            this.openDialog_button.Size = new System.Drawing.Size(80, 28);
            this.openDialog_button.TabIndex = 2;
            this.openDialog_button.Text = "Open Dialog";
            this.openDialog_button.UseVisualStyleBackColor = true;
            // 
            // zoomplus_btn
            // 
            this.zoomplus_btn.Location = new System.Drawing.Point(26, 394);
            this.zoomplus_btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.zoomplus_btn.Name = "zoomplus_btn";
            this.zoomplus_btn.Size = new System.Drawing.Size(30, 32);
            this.zoomplus_btn.TabIndex = 3;
            this.zoomplus_btn.Text = "+";
            this.zoomplus_btn.UseVisualStyleBackColor = true;
            this.zoomplus_btn.Click += new System.EventHandler(this.zoomplus_btn_Click_1);
            // 
            // zoomminus_btn
            // 
            this.zoomminus_btn.Location = new System.Drawing.Point(26, 429);
            this.zoomminus_btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.zoomminus_btn.Name = "zoomminus_btn";
            this.zoomminus_btn.Size = new System.Drawing.Size(30, 32);
            this.zoomminus_btn.TabIndex = 4;
            this.zoomminus_btn.Text = "-";
            this.zoomminus_btn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 507);
            this.Controls.Add(this.zoomminus_btn);
            this.Controls.Add(this.zoomplus_btn);
            this.Controls.Add(this.openDialog_button);
            this.Controls.Add(this.SaveMap);
            this.Controls.Add(this.gmap);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.Button SaveMap;
        private System.Windows.Forms.Button openDialog_button;
        private System.Windows.Forms.Button zoomplus_btn;
        private System.Windows.Forms.Button zoomminus_btn;
    }
}

