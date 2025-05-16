using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23
{
    public partial class InstructionsForm : Form
    {
        public InstructionsForm()
        {
            InitializeComponent();

            txtInstructions.Text = "Данная программа визуализирует очередь на основе массива.\n\n" +
                "Используйте кнопки для управления очередью:\n" +
                "- Enqueue: добавить элемент в конец очереди\n" +
                "- Dequeue: удалить элемент из начала очереди\n" +
                "- Clear: очистить очередь\n" +
                "- Back/Forward: навигация по истории операций\n" +
                "- Save/Load: сохранение и загрузка состояния очереди\n\n" +
                "Capacity: изменение размера очереди";
        }
    }
}
