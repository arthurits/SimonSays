using System;
using System.Collections.Generic;
using System.Text;
using LaMarvin.Windows.Forms;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace ColorPickerCombo
{
    public class ColorPickerColumn : DataGridViewColumn
    {
        public ColorPickerColumn():base(new ColorPickerCell())
        {
        
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a CalendarCell.
                if (value != null && 
                    !value.GetType().IsAssignableFrom(typeof(ColorPickerCell)))
                {
                    throw new InvalidCastException("Must be a ColorPicker");
                }
                base.CellTemplate = value;
            }
        }
    }

    public class ColorPickerCell : DataGridViewTextBoxCell 
    {
        ColorPickerControl _ColorPicker;
        public ColorPickerCell()
            : base()
        {
        
           
        }
      
        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                                          dataGridViewCellStyle);
            ColorPickerControl ctl = DataGridView.EditingControl as ColorPickerControl;
            _ColorPicker = ctl;
            
            if (this.Value !=null && (this.Value.GetType() == typeof(Color)))
            {
                ctl.Color = (Color)this.Value;
            }
        }

        public override Type EditType
        {
            get
            {
               //Return the type of the editing contol that CalendarCell uses.
             return typeof(ColorPickerControl);
            }
        }
    
        public override Type ValueType
        {
            get
            {
                // Return the type of the value that CalendarCell contains.
               return typeof(Color);
            }
        }
        
        public override object DefaultNewRowValue
        {
            get
            {
                // Use the current date and time as the default value.
                return Color.White;
            }
        }
     
        protected override void Paint(Graphics graphics,
                                        Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
                                        DataGridViewElementStates elementState, object value,
                                        object formattedValue, string errorText,
                                        DataGridViewCellStyle cellStyle,
                                        DataGridViewAdvancedBorderStyle advancedBorderStyle,
                                        DataGridViewPaintParts paintParts)
        {
            formattedValue = null;
            
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue,
                       errorText, cellStyle, advancedBorderStyle, paintParts);

           
            Rectangle ColorBoxRect = new Rectangle();
            RectangleF TextBoxRect = new RectangleF();
            GetDisplayLayout(cellBounds, ref ColorBoxRect, ref TextBoxRect);

            //// Draw the cell background, if specified.
            if ((paintParts & DataGridViewPaintParts.Background) ==
                DataGridViewPaintParts.Background)
            {
                SolidBrush cellBackground;
                if (value != null && value.GetType() == typeof(Color))
                {
                    cellBackground = new SolidBrush((Color)value);
                }
                else
                {
                    cellBackground =  new SolidBrush(cellStyle.BackColor);
                }
                graphics.FillRectangle(cellBackground, ColorBoxRect);
                graphics.DrawRectangle(Pens.Black, ColorBoxRect);
                Color lclcolor=(Color)value;
                graphics.DrawString(lclcolor.Name.ToString(), cellStyle.Font, System.Drawing.Brushes.Black, TextBoxRect);
            
                cellBackground.Dispose();
            }
                
        }

        public override object ParseFormattedValue(object formattedValue, DataGridViewCellStyle cellStyle, System.ComponentModel.TypeConverter formattedValueTypeConverter, System.ComponentModel.TypeConverter valueTypeConverter)
        {
            int result;
            string number = "0x" + formattedValue.ToString();
            if (int.TryParse(formattedValue.ToString(), System.Globalization.NumberStyles.HexNumber, null, out result))
                //Hex number
                return base.ParseFormattedValue("0x" + formattedValue.ToString(), cellStyle, formattedValueTypeConverter, valueTypeConverter);
            else
                return base.ParseFormattedValue(formattedValue, cellStyle, formattedValueTypeConverter, valueTypeConverter);
        }

        protected virtual void GetDisplayLayout(Rectangle CellRect,ref Rectangle colorBoxRect, ref RectangleF textBoxRect)
        {
            const int DistanceFromEdge = 2;
           
            colorBoxRect.X = CellRect.X+DistanceFromEdge ;
            colorBoxRect.Y = CellRect.Y +1 ;
            colorBoxRect.Size = new Size((int)(1.5 * 17), CellRect.Height - (2*DistanceFromEdge));

            // The text occupies the middle portion.
            textBoxRect = RectangleF.FromLTRB(colorBoxRect.X + colorBoxRect.Width + 5, colorBoxRect.Y+2, CellRect.X+CellRect.Width-DistanceFromEdge , colorBoxRect.Y + colorBoxRect.Height  );
        }
    }

    class ColorPickerControl : ColorPicker , IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;
       
        public ColorPickerControl()
        {
            
        }

        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
        // property.
        public object EditingControlFormattedValue
        {
            get
            {
                return this;
            }
            set
            {
                this.Color = Color.Pink;
            }
        }

        // Implements the 
        // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return Color.Name;
        }

        // Implements the 
        // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
        public void ApplyCellStyleToEditingControl(
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
        }

        // Implements the IDataGridViewEditingControl.EditingControlRowIndex 
        // property.
        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey 
        // method.
        public bool EditingControlWantsInputKey(
            Keys key, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed.
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit 
        // method.
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // No preparation needs to be done.
        }

        // Implements the IDataGridViewEditingControl
        // .RepositionEditingControlOnValueChange property.
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlDataGridView property.
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlValueChanged property.
        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }

        // Implements the IDataGridViewEditingControl
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        protected virtual void NotifyDataGridViewOfValueChange()
        {
            this.valueChanged = true;
            if (this.dataGridView != null)
            {
                this.dataGridView.NotifyCurrentCellDirty(true);
            }
        }

        protected override void OnLeave(EventArgs eventargs)
        {
            // Notify the DataGridView that the contents of the cell
            // have changed.
            base.OnLeave(eventargs);
            NotifyDataGridViewOfValueChange();
        }

    }
}
