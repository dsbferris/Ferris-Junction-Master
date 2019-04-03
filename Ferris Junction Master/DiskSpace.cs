using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Ferris_Junction_Master.DirSizeCalculation;

namespace Ferris_Junction_Master
{
    public partial class DiskSpace : UserControl
    {
        public DiskSpace(long total, long used, long directory, long free, int totalwidth, bool IsAdd = true)
        {
            InitializeComponent();
            SpaceTotal = total;
            SpaceUsed = used;
            SpaceFree = free;
            SpaceDirectory = directory;
            this.Width = totalwidth;
            if (IsAdd)
            {
                TbSpaceUsed.Text = ToReadableBytes(used);
                TbSpaceFree.Text = ToReadableBytes(free - directory);
                TbSpaceChanging.BackColor = Color.Crimson;
            }
            else
            {
                TbSpaceUsed.Text = ToReadableBytes(used - directory);
                TbSpaceFree.Text = ToReadableBytes(free);
                TbSpaceChanging.BackColor = Color.LimeGreen;
            }
            
            TbSpaceChanging.Text = ToReadableBytes(directory);

            DiskUsage(totalwidth, SizeScaleFactor(new long[] { total, free, used, directory }), IsAdd);
        }

        public DiskSpace(string folder, string DriveSource, string DriveTarget)
        {

        }

        public long SpaceTotal { get; set; }
        public long SpaceUsed { get; set; }
        public long SpaceFree { get; set; }
        public long SpaceDirectory { get; set; }

        private Color _SpaceFreeColor = Color.LightGray;
        private Color _SpaceUsedColor = Color.DodgerBlue;
        private Color _SpaceChangingColor = Color.Crimson; //Color.Crimson or 

        public Color SpaceFreeColor
        {
            get
            {
                return _SpaceFreeColor;
            }
            set
            {
                _SpaceFreeColor = value;
                TbSpaceFree.BackColor = value;
            }
        }
        public Color SpaceUsedColor
        {
            get
            {
                return _SpaceUsedColor;
            }
            set
            {
                _SpaceUsedColor = value;
                TbSpaceUsed.BackColor = value;
            }
        }
        public Color SpaceChangingColor
        {
            get
            {
                return _SpaceChangingColor;
            }
            set
            {
                _SpaceChangingColor = value;
                TbSpaceChanging.BackColor = value;
            }
        }

        public void DiskUsage(int totalwidth, long scalefactor, bool IsAdd)
        {
            double px_per_byte = totalwidth / (SpaceTotal / scalefactor);
            if (IsAdd)
            {
                TbSpaceUsed.Width = GetWidth(px_per_byte, SpaceUsed / scalefactor);
                TbSpaceFree.Width = GetWidth(px_per_byte, (SpaceFree - SpaceDirectory) / scalefactor);
            }
            else
            {
                TbSpaceUsed.Width = GetWidth(px_per_byte, (SpaceUsed - SpaceDirectory) / scalefactor);
                TbSpaceFree.Width = GetWidth(px_per_byte, SpaceFree / scalefactor);
            }

            TbSpaceChanging.Width = GetWidth(px_per_byte, SpaceDirectory / scalefactor);

            TbSpaceUsed.Location = new Point(0, 0);
            TbSpaceChanging.Location = new Point(TbSpaceUsed.Size.Width, 0);

            TbSpaceFree.Location = new Point(TbSpaceChanging.Location.X + TbSpaceChanging.Size.Width, 0);
            this.Width = TbSpaceFree.Location.X + TbSpaceFree.Size.Width;
            //ExplorerContextMenu.logger.Debug(ExplorerContextMenu.FLog($"TotalWidth: {totalwidth}, UsedWidth: {TbSpaceUsed.Width"));
        }

        private int GetWidth(double scale, long size)
        {
            return (int)(size * scale);
        }


        
    }
}
