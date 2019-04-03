using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Ferris_Junction_Master.DirSizeCalculation;
using static Ferris_Junction_Master.ExplorerContextMenu;

namespace Ferris_Junction_Master
{
    public partial class FormPasteFolder : MetroFramework.Forms.MetroForm
    {
        public FormPasteFolder()
        {
            InitializeComponent();
        }
        

        private Task<long> GetDirSizeAsync(string DirPath)
        {
            return Task.FromResult(DirSizeCalculation.GetDirSize(DirPath));
        }

        private async void FormPasteFolder_Load(object sender, EventArgs e)
        {
            long dirSize = await GetDirSizeAsync(@"F:\Games\Grand Theft Auto V");
            DriveInfo driveInfo = new DriveInfo("F");
            long total = driveInfo.TotalSize;
            long free = driveInfo.AvailableFreeSpace;
            long used = total - free;

            logger.Debug(FLog($"Directory: {ToReadableBytes(dirSize)}, TotalSpace: {ToReadableBytes(total)}, AvFreeSpace: {ToReadableBytes(free)}, UsedSpace: {ToReadableBytes(used)}"));

            DiskSpace ds1 = new DiskSpace(total: total, used: used, free: free, directory: dirSize, totalwidth: panel1.Size.Width, IsAdd: true);
            panel1.Controls.Add(ds1);
            foreach (Control c in panel1.Controls)
            {
                c.Dock = DockStyle.Fill;
            }
            DiskSpace ds2 = new DiskSpace(total: total, used: used, free: free, directory: dirSize, totalwidth: panel1.Size.Width, IsAdd: false);
            panel2.Controls.Add(ds2);
            foreach (Control c in panel2.Controls)
            {
                c.Dock = DockStyle.Fill;
            }

        }
    }
}
