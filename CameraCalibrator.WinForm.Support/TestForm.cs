﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CameraCalibrator.WinForm.Support
{
	public partial class TestForm : Form
	{
		private TestFormModel m_Model;
		private bool m_StopProcessing;

		public TestForm(TestFormModel model)
		{
			m_Model = model;
			InitializeComponent();
			m_ImagesSplitter.SplitterDistance = m_ImagesSplitter.Width / 2;
			Application.Idle += ProcessFrame;
		}

		private void ProcessFrame(object sender, EventArgs e)
		{
			if (m_StopProcessing)
			{
				return;
			}
			m_Model.ProcessFrame();

			m_RawImageBoxWithHeading.ImageBox.Image = m_Model.OriginalImage;
			m_CorrectedImageBoxWithHeading.ImageBox.Image = m_Model.CorrectedImage;
		}

		private void OnOKButtonClick(object sender, EventArgs e)
		{
			m_StopProcessing = true;
			Application.Idle -= ProcessFrame;
			this.Close();
		}
	}
}
