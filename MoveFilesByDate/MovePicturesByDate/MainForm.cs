using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MovePicturesByDate
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            treeView1.CheckBoxes = true;
            treeView1.AfterCheck += TreeView1_AfterCheck;
        }

        private void TreeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                e.Node.TreeView.BeginUpdate();
                if (e.Node.Nodes.Count > 0)
                {
                    var parentNode = e.Node;
                    var nodes = e.Node.Nodes;
                    CheckedOrUnCheckedNodes(parentNode, nodes);
                }
            }
            finally
            {
                e.Node.TreeView.EndUpdate();
            }
        }

        private void CheckedOrUnCheckedNodes(TreeNode parentNode, TreeNodeCollection nodes)
        {
            if (nodes.Count > 0)
            {
                foreach (TreeNode node in nodes)
                {
                    node.Checked = parentNode.Checked;
                    CheckedOrUnCheckedNodes(parentNode, node.Nodes);
                }
            }
        }

        private void _btnSource_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = false;
            var fdres = folderBrowserDialog1.ShowDialog();
            if (fdres == DialogResult.OK)
            {
                _txtSource.Text = folderBrowserDialog1.SelectedPath;
                Cursor.Current = Cursors.WaitCursor;
                ListDirectory(treeView1, _txtSource.Text);
                Cursor.Current = Cursors.Default;
            }
        }

        private static void ListDirectory(TreeView treeView, string path)
        {
            treeView.Nodes.Clear();

            var stack = new Stack<TreeNode>();
            var rootDirectory = new DirectoryInfo(path);
            if ((rootDirectory.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden) return;
            var node = new TreeNode(rootDirectory.Name) { Tag = rootDirectory };
            stack.Push(node);

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();
                var directoryInfo = (DirectoryInfo)currentNode.Tag;
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    if ((directory.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden) continue;
                    var childDirectoryNode = new TreeNode(directory.Name) { Tag = directory };
                    currentNode.Nodes.Add(childDirectoryNode);
                    stack.Push(childDirectoryNode);
                }
                if ((directoryInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden) continue;
                foreach (var file in directoryInfo.GetFiles())
                    currentNode.Nodes.Add(new TreeNode(file.Name));
            }
            treeView.Nodes.Add(node);
        }

        private void _btnTarget_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = true;
            var fdres = folderBrowserDialog1.ShowDialog();
            if (fdres == DialogResult.OK)
            {
                _txtTarget.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private Log _logForm;

        private void _btnGo_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (string.IsNullOrEmpty(_txtTarget.Text)) return;
            var target = _txtTarget.Text.Trim();
            if (_logForm != null)
            {
                _logForm.ClearForm();
                _logForm.Show();
            }
            else
            {
                _logForm = new Log();
                _logForm.ClosingEvent += _logForm_ClosingEvent;
                _logForm.Show();
            }
            ProcessNodes(treeView1.TopNode);
            Cursor.Current = Cursors.Default;
        }

        private void _logForm_ClosingEvent(object sender, EventArgs e)
        {
            _logForm.ClosingEvent -= _logForm_ClosingEvent;
            _logForm = null;
        }

        private void ProcessNodes(TreeNode node)
        {
            if (node.Nodes.Count == 0)
            {
                if ( node.Tag == null && node.Checked)
                {
                    var file = Path.Combine((node.Parent.Tag as DirectoryInfo).FullName, node.Text);
                    ProcessFile(file);
                }
            }
            else
            {
                foreach (TreeNode nodeNext in node.Nodes)
                    ProcessNodes(nodeNext);
            }
        }
        private void ProcessFile(string file)
        {
            //  get target directory
            var fpath = GetDirPath(file);
            //  create it
            Directory.CreateDirectory(fpath);
            var line = string.Format("\"{0}\",\"{1}\"", file, fpath);
            _logForm.AppendText(line);
            //  copy the files
            var tofile = Path.GetFileName(file);
            CopyFile(file, Path.Combine(fpath, tofile));
        }

        private string GetDirPath(string fileName)
        {
            var fi = new FileInfo(fileName);
            var ct = fi.CreationTime;
            var year = ct.Year.ToString();
            var month = string.Format("{0}-{1}", ct.Month.ToString("D2"), ct.ToString("MMM"));
            var day = string.Format("{0}-{1}", ct.Day.ToString("D2"), ct.ToString("ddd"));

            var fPath = Path.Combine(_txtTarget.Text, year);
            fPath = Path.Combine(fPath, month);
            fPath = Path.Combine(fPath, day);

            return fPath;
        }

        public static void CopyFile(string copyFromPath, string copyToPath)
        {
            if (File.Exists(copyToPath))
            {
                var target = new FileInfo(copyToPath);
                if (target.IsReadOnly)
                    target.IsReadOnly = false;
            }

            var origin = new FileInfo(copyFromPath);
            origin.CopyTo(copyToPath, true);

            var destination = new FileInfo(copyToPath);
            if (destination.IsReadOnly)
            {
                destination.IsReadOnly = false;
                destination.CreationTime = origin.CreationTime;
                destination.LastWriteTime = origin.LastWriteTime;
                destination.LastAccessTime = origin.LastAccessTime;
                destination.IsReadOnly = true;
            }
            else
            {
                destination.CreationTime = origin.CreationTime;
                destination.LastWriteTime = origin.LastWriteTime;
                destination.LastAccessTime = origin.LastAccessTime;
            }
        }
    }
}
