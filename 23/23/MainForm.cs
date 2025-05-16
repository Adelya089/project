using QueueVisualization.Model;
using Newtonsoft.Json;

namespace QueueVisualization
{
    public partial class MainForm : Form
    {
        private QueueVisualization.Model.Queue _queue;
        private List<QueueState> _history = new List<QueueState>();
        private int _historyIndex = -1;
        private int _capacity = 15;
        private int cellWidth = 30;
        private int cellHeight = 30;
        private List<Label> _animationLabels = new List<Label>(); // Список Label для анимации

        public MainForm()
        {
            InitializeComponent();
            _queue = new QueueVisualization.Model.Queue(_capacity);
            _queue.QueueChanged += _queue_QueueChanged;
            UpdateQueuePanel();
            UpdateHeadTailLabels();
        }


        private void _queue_QueueChanged(object sender, EventArgs e)
        {
            UpdateQueuePanel();
            UpdateHeadTailLabels();
        }

        private void UpdateQueuePanel()
        {
            // Создаем Bitmap для рисования
            Bitmap queueBitmap = new Bitmap(queuePanel.Width, queuePanel.Height);
            using (Graphics g = Graphics.FromImage(queueBitmap))
            {
                g.Clear(queuePanel.BackColor); // Очищаем фон

                int rectWidth = 50;
                int rectHeight = 50;
                int margin = 10;
                int indexHeight = 20; // Высота для индексов
                int totalHeight = rectHeight + indexHeight + margin; // Общая высота для прямоугольника с индексом

                var queueArray = _queue.GetArrayCopy();

                // Проверяем, пустой ли массив
                if (queueArray == null || queueArray.Length == 0)
                    return;

                // Увеличиваем шрифт для вывода
                using (Font font = new Font("Arial", 12, FontStyle.Bold))
                using (Font indexFont = new Font("Arial", 8, FontStyle.Regular))
                {
                    for (int i = 0; i < queueArray.Length; i++)
                    {
                        Rectangle rect = new Rectangle(i * (rectWidth + margin), 10, rectWidth, rectHeight);
                        g.FillRectangle(Brushes.LightGray, rect);
                        g.DrawRectangle(Pens.Black, rect);

                        // Проверяем, есть ли элемент в очереди
                        string text = queueArray[i].ToString();
                        if (string.IsNullOrEmpty(text) || text == "0") // Проверка на пустоту или ноль
                        {
                            text = ""; // Пустое значение
                        }

                        // Центрируем текст
                        SizeF textSize = g.MeasureString(text, font);
                        float textX = rect.X + (rect.Width - textSize.Width) / 2;
                        float textY = rect.Y + (rect.Height - textSize.Height) / 2;

                        g.DrawString(text, font, Brushes.Black, textX, textY);

                        // Рисуем индекс под прямоугольником
                        Rectangle indexRect = new Rectangle(rect.X, rect.Y + rectHeight + margin, rectWidth, indexHeight);
                        g.FillRectangle(Brushes.LightGray, indexRect);
                        g.DrawRectangle(Pens.Black, indexRect);

                        // Печатаем индекс
                        string indexText = i.ToString();
                        SizeF indexTextSize = g.MeasureString(indexText, indexFont);
                        float indexTextX = indexRect.X + (indexRect.Width - indexTextSize.Width) / 2;
                        float indexTextY = indexRect.Y + (indexRect.Height - indexTextSize.Height) / 2;

                        g.DrawString(indexText, indexFont, Brushes.Black, indexTextX, indexTextY);
                    }
                }
            }

            // Очищаем panel и добавляем PictureBox с нарисованной очередью
            queuePanel.Controls.Clear();
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = queueBitmap;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.Dock = DockStyle.Fill;
            queuePanel.Controls.Add(pictureBox);
        }

        private void UpdateHeadTailLabels()
        {
            headLabel.Text = "Head: ";
            tailLabel.Text = "Tail: ";
            headValueLabel.Text = _queue.Head.ToString();
            tailValueLabel.Text = _queue.Tail.ToString();
        }


        // Обработчики кнопок
        private void EnqueueButton_Click(object sender, EventArgs e)
        {
            // Открываем InputForm и подписываемся на событие DataEntered
            InputForm inputForm = new InputForm();
            inputForm.DataEntered += (s, args) =>
            {
                try
                {
                    StartEnqueueAnimation(args.Value); // Запускаем анимацию
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            inputForm.ShowDialog();
        }

        private void DequeueButton_Click(object sender, EventArgs e)
        {
            try
            {
                StartDequeueAnimation();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            _queue.Clear();
            SaveStateToHistory();
            UpdateQueuePanel();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            GoBack();
            UpdateQueuePanel();
        }

        private void ForwardButton_Click(object sender, EventArgs e)
        {
            GoForward();
            UpdateQueuePanel();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveState();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadState();
            UpdateQueuePanel();
        }

        // История состояний
        private void SaveStateToHistory()
        {
            if (_historyIndex < _history.Count - 1)
            {
                _history.RemoveRange(_historyIndex + 1, _history.Count - _historyIndex - 1);
            }
            _history.Add(_queue.GetState());
            _historyIndex = _history.Count - 1;
        }

        private void GoBack()
        {
            if (_historyIndex > 0)
            {
                _historyIndex--;
                _queue.SetState(_history[_historyIndex]);
                UpdateQueuePanel();
            }
        }

        private void GoForward()
        {
            if (_historyIndex < _history.Count - 1)
            {
                _historyIndex++;
                _queue.SetState(_history[_historyIndex]);
                UpdateQueuePanel();
            }
        }

        // Сохранение/Загрузка состояния
        private void SaveState()
        {
            try
            {
                string json = JsonConvert.SerializeObject(_queue.GetState());
                File.WriteAllText("queue_state.json", json);
                MessageBox.Show("Состояние сохранено.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadState()
        {
            try
            {
                if (File.Exists("queue_state.json"))
                {
                    string json = File.ReadAllText("queue_state.json");
                    QueueState state = JsonConvert.DeserializeObject<QueueState>(json);
                    _queue.SetState(state);
                    // Очищаем историю и добавляем загруженное состояние
                    _history.Clear();
                    _history.Add(state);
                    _historyIndex = 0;
                    UpdateQueuePanel();
                    MessageBox.Show("Состояние загружено.", "Загрузка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Файл состояния не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void capacityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _capacity = (int)capacityNumericUpDown.Value;
                _queue = new QueueVisualization.Model.Queue(_capacity);
                _queue.QueueChanged += _queue_QueueChanged;
                UpdateQueuePanel();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------------------- Анимация -------------------

        private void StartEnqueueAnimation(int value)
        {
            // Создаем Label для анимации
            Label animationLabel = new Label();
            animationLabel.Text = value.ToString();
            animationLabel.TextAlign = ContentAlignment.MiddleCenter;
            animationLabel.Width = cellWidth;
            animationLabel.Height = cellHeight;
            animationLabel.Font = new Font(this.Font.FontFamily, 10);
            animationLabel.BorderStyle = BorderStyle.FixedSingle;
            animationLabel.BackColor = Color.LightGreen;

            // Начальная позиция - рядом с Tail
            animationLabel.Left = tailPanel.Left + tailValueLabel.Left;
            animationLabel.Top = tailPanel.Top + tailValueLabel.Top;

            this.Controls.Add(animationLabel);
            animationLabel.BringToFront();
            _animationLabels.Add(animationLabel);

            // Целевая позиция - ячейка в массиве
            int targetIndex = _queue.Tail;
            int targetX = queuePanel.Left + targetIndex * cellWidth;
            int targetY = queuePanel.Top;

            // Анимация с явным указанием типа таймера
            System.Windows.Forms.Timer animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 10;

            var animationData = new
            {
                Label = animationLabel,
                StartX = animationLabel.Left,
                StartY = animationLabel.Top,
                TargetX = targetX,
                TargetY = targetY,
                Value = value,
                StartTime = DateTime.Now
            };

            animationTimer.Tick += (s, e) =>
            {
                double elapsed = (DateTime.Now - animationData.StartTime).TotalMilliseconds;
                double progress = elapsed / 500; // 500ms duration

                // Плавное движение
                animationData.Label.Left = (int)(animationData.StartX +
                                        (animationData.TargetX - animationData.StartX) * progress);
                animationData.Label.Top = (int)(animationData.StartY +
                                       (animationData.TargetY - animationData.StartY) * progress);

                if (progress >= 1.0)
                {
                    animationTimer.Stop();
                    this.Controls.Remove(animationData.Label);
                    _animationLabels.Remove(animationData.Label);
                    animationData.Label.Dispose();

                    _queue.Enqueue(animationData.Value);
                    SaveStateToHistory();
                    UpdateQueuePanel();
                    animationTimer.Dispose();
                }
            };

            animationTimer.Start();
        }

        private void StartDequeueAnimation()
        {
            if (_queue.IsEmpty) return;

            // Получаем значение из головы
            int value = _queue.GetArrayCopy()[_queue.Head];

            // Создаем Label для анимации
            Label animationLabel = new Label();
            animationLabel.Text = value.ToString();
            animationLabel.TextAlign = ContentAlignment.MiddleCenter;
            animationLabel.Width = cellWidth;
            animationLabel.Height = cellHeight;
            animationLabel.Font = new Font(this.Font.FontFamily, 10);
            animationLabel.BorderStyle = BorderStyle.FixedSingle;
            animationLabel.BackColor = Color.LightCoral;

            // Начальная позиция - ячейка в массиве
            int startX = queuePanel.Left + _queue.Head * cellWidth;
            int startY = queuePanel.Top;
            animationLabel.Left = startX;
            animationLabel.Top = startY;

            this.Controls.Add(animationLabel);
            animationLabel.BringToFront();
            _animationLabels.Add(animationLabel);

            // Целевая позиция - рядом с Head
            int targetX = headPanel.Left + headValueLabel.Left;
            int targetY = headPanel.Top + headValueLabel.Top;

            // Анимация с явным указанием типа таймера
            System.Windows.Forms.Timer animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 10;

            var animationData = new
            {
                Label = animationLabel,
                StartX = startX,
                StartY = startY,
                TargetX = targetX,
                TargetY = targetY,
                Value = value,
                StartTime = DateTime.Now
            };

            animationTimer.Tick += (s, e) =>
            {
                double elapsed = (DateTime.Now - animationData.StartTime).TotalMilliseconds;
                double progress = elapsed / 500; // 500ms duration

                // Плавное движение
                animationData.Label.Left = (int)(animationData.StartX +
                                        (animationData.TargetX - animationData.StartX) * progress);
                animationData.Label.Top = (int)(animationData.StartY +
                                       (animationData.TargetY - animationData.StartY) * progress);

                if (progress >= 1.0)
                {
                    animationTimer.Stop();
                    this.Controls.Remove(animationData.Label);
                    _animationLabels.Remove(animationData.Label);
                    animationData.Label.Dispose();

                    _queue.Dequeue();
                    SaveStateToHistory();
                    UpdateQueuePanel();
                    animationTimer.Dispose();
                }
            };

            animationTimer.Start();
        }
    }
}