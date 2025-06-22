namespace WinFormsApp3
{
    public partial class Game : Form
    {
        Button button1;
        public bool Mdown;
        public bool Mup;
        public bool Mleft;
        public bool Mright;

        int WorldWidth = 3000;
        int WorldHeight = 3000;
        Form2 form = new Form2();

        int ViewportWidth = 600;
        int ViewportHeight = 600;

        public int CameraX = 0;
        public int CameraY = 0;



        List<Control> gameObjects = new List<Control>();

        public Game()
        {
            Mdown = false;
            Mup = false;
            Mleft = false;
            Mright = false;
            InitializeComponent();

            this.ClientSize = new Size(ViewportWidth, ViewportHeight);

            Init();
            this.KeyPreview = true;
            int fps = 100;
            System.Windows.Forms.Timer movementTimer = new System.Windows.Forms.Timer();
            movementTimer.Interval = (1000 / fps);
            movementTimer.Tick += MovementTimer_Tick;
            movementTimer.Start();


            System.Windows.Forms.Timer cameraTimer = new System.Windows.Forms.Timer();
            cameraTimer.Interval = (1000 / fps);
            cameraTimer.Tick += CameraTimer_Tick;
            cameraTimer.Start();
        }

        private void CameraTimer_Tick(object sender, EventArgs e)
        {
            var playerWorldPos = (KeyValuePair<int, int>)button1.Tag;
            int targetX = playerWorldPos.Value - ((ViewportWidth - button1.Size.Width) / 2);
            int targetY = playerWorldPos.Key - ((ViewportHeight- button1.Size.Height) / 2);

            CameraX += (int)((targetX - CameraX)*0.1);
            CameraY += (int)((targetY - CameraY)*0.1);

            CameraX = Math.Max(CameraX, Math.Min(CameraX, WorldWidth - ViewportWidth));
            CameraY = Math.Max(CameraY, Math.Min(CameraY, WorldHeight - ViewportHeight));
            button1.Location = new Point(playerWorldPos.Value - CameraX, playerWorldPos.Key - CameraY);
            UpdateObjectsPosition();
        }

        private void UpdateObjectsPosition()
        {
            string text = "";
            foreach (var obj in gameObjects)
            {
                KeyValuePair<int, int>? coords = (KeyValuePair<int, int>)obj.Tag;

                int screenX = coords.Value.Value - CameraX;
                int screenY = coords.Value.Key - CameraY;


                if (screenX + obj.Width > 0 && screenX < ViewportWidth &&
                    screenY + obj.Height > 0 && screenY < ViewportHeight)
                {
                    if (obj.Name != "player")
                    {
                        obj.Location = new Point(screenX, screenY);

                        obj.Visible = true;
                    }

                }
                else
                {
                  // obj.Location = new Point(obj.Location.X - CameraX, obj.Location.Y - CameraY);
                    obj.Visible = false;
                }
                text += $"{obj.GetHashCode()} | {obj.Name} : {obj.Location} | {obj.Visible}\n";
            }
            text += $"{CameraX}, {CameraY} | {button1.Location.X} , {button1.Location.Y}";
            form.label.Text = text;
        }

        private void MovementTimer_Tick(object sender, EventArgs e)
        {
            int deltaX = 0, deltaY = 0;

            if (Mright) deltaX += 3;
            if (Mleft) deltaX -= 3;
            if (Mup) deltaY -= 3;
            if (Mdown) deltaY += 3;

            if (deltaX != 0 || deltaY != 0)
            {

                var worldPos = (KeyValuePair<int, int>)button1.Tag;
                int newX = worldPos.Value + deltaX;
                int newY = worldPos.Key + deltaY;

                newX = Math.Max(0, Math.Min(newX, WorldWidth - button1.Width));
                newY = Math.Max(0, Math.Min(newY, WorldHeight - button1.Height));


                button1.Tag = new KeyValuePair<int, int>(newY, newX);
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
            button1.Tag = new KeyValuePair<int, int>(button1.Location.X, button1.Location.Y);
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
                obj.Tag = new KeyValuePair<int, int>(obj.Location.X, obj.Location.Y);
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
            label.Location = new Point(10, 0);
            label.Text = " 123";
            label.Width = 400;
            label.Height = 600;
            Controls.Add(label);

        }
    }

}