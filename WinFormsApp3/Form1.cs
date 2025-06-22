namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        Button button1;
        public bool Mdown;
        public bool Mup;
        public bool Mleft;
        public bool Mright;

        int WorldWidth = 1000;
        int WorldHeight = 1000;
        Form2 form = new Form2();

        int ViewportWidth = 400;
        int ViewportHeight = 400;

        public int CameraX = 0;
        public int CameraY = 0;
        public int localX = 0;
        public int localY = 0;

        List<Control> gameObjects = new List<Control>();

        public Form1()
        {
            Mdown = false;
            Mup = false;
            Mleft = false;
            Mright = false;
            InitializeComponent();

            this.ClientSize = new Size(ViewportWidth, ViewportHeight);

            Init();
            this.KeyPreview = true;

            System.Windows.Forms.Timer movementTimer = new System.Windows.Forms.Timer();
            movementTimer.Interval = 10;
            movementTimer.Tick += MovementTimer_Tick;
            movementTimer.Start();
            int fps = 100;

            System.Windows.Forms.Timer cameraTimer = new System.Windows.Forms.Timer();
            cameraTimer.Interval = (1000/fps); 
            cameraTimer.Tick += CameraTimer_Tick;
            cameraTimer.Start();
        }

        private void CameraTimer_Tick(object sender, EventArgs e)
        {
            int targetX = button1.Location.X - ViewportWidth / 2;
            int targetY = button1.Location.Y - ViewportHeight / 2;

            CameraX += (int)((targetX - CameraX));
            CameraY += (int)((targetY - CameraY));

            CameraX = Math.Max(CameraX, Math.Min(CameraX, WorldWidth - ViewportWidth));
            CameraY = Math.Max(CameraY, Math.Min(CameraY, WorldHeight - ViewportHeight));

            UpdateObjectsPosition();
        }

        private void UpdateObjectsPosition()
        {
            string text = "";
            foreach (var obj in gameObjects)
            {

                int screenX = obj.Location.X - CameraX;
                int screenY = obj.Location.Y - CameraY;


                if (screenX + obj.Width > 0 && screenX < ViewportWidth &&
                    screenY + obj.Height > 0 && screenY < ViewportHeight)
                { 
                    obj.Location = new Point(screenX, screenY);
                    obj.Visible = true; 
                    
                }
                else
                {
                    obj.Visible = false;
                }
                text += $"{obj.GetHashCode()} | {obj.Name} : {obj.Location} | {obj.Visible}\n";
            }
            text += $"{CameraX}, {CameraY} {localX} {localY}";
            form.label.Text = text; 
        }

        private void MovementTimer_Tick(object sender, EventArgs e)
        {
            int deltaX = 0, deltaY = 0;

            if (Mright) deltaX += 3;
            if (Mleft) deltaX -= 3;
            if (Mup) deltaY -= 3;
            if (Mdown) deltaY += 3;
            localX += deltaX;
            localY += deltaY;
            if (deltaX != 0 || deltaY != 0)
            {
                int newX = button1.Location.X + deltaX + CameraX;
                int newY = button1.Location.Y + deltaY + CameraY;
                newX = Math.Max(0, Math.Min(newX, WorldWidth - button1.Width));
                newY = Math.Max(0, Math.Min(newY, WorldHeight - button1.Height));
                button1.Location = new Point(newX - CameraX, newY - CameraY);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D) Mright = true;
            else if (e.KeyCode == Keys.W) Mup = true;
            else if (e.KeyCode == Keys.S) Mdown = true;
            else if (e.KeyCode == Keys.A) Mleft = true;

            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D) Mright = false;
            else if (e.KeyCode == Keys.W) Mup = false;
            else if (e.KeyCode == Keys.S) Mdown = false;
            else if (e.KeyCode == Keys.A) Mleft = false;

            base.OnKeyUp(e);
        }

        public void Init()
        {
            button1 = new Button();
            button1.Location = new Point(ViewportWidth / 2, ViewportHeight / 2); 
            button1.Name = "player";
            button1.Size = new Size(40, 40);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;

            Controls.Add(button1);
            gameObjects.Add(button1);
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                Button obj = new Button();
                
                obj.Location = new Point(rnd.Next(WorldWidth), rnd.Next(WorldHeight));
                obj.Size = new Size(30, 30);
                obj.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                obj.Name = obj.BackColor.Name;
                Controls.Add(obj);
                gameObjects.Add(obj);
            }
            
            form.Show();
            
        }
    }
    
    public class Form2 : Form
    {
        public Label label;
        public Form2()
        {
            this.ClientSize = new Size(400, 600);
            label = new Label();
            label.Location = new Point(10,0);
            label.Text = " 123";
            label.Width = 400;
            label.Height = 600;
            Controls.Add (label);

        }
    }

}