using UnityEngine;
using UnityEngine.UI;
using EnhancedUI.EnhancedScroller;
using System.Collections.Generic;

namespace EnhancedScrollerDemos.SuperSimpleDemo
{
    /// <summary>
    /// This is the view of our cell which handles how the cell looks.
    /// </summary>
    public class CellView : EnhancedScrollerCellView
    {
        /// <summary>
        /// A reference to the UI Text element to display the cell data
        /// </summary>
        public Text someTextText;

        /// <summary>
        /// This function just takes the Demo data and displays it
        /// </summary>
        /// <param name="data"></param>
        public virtual void SetData(Data data)
        {
            // update the UI text with the cell data
            someTextText.text = "Mode " +(data.indexStage + 1).ToString();
        }
        public virtual void SetData(List<Data> data)
        {
            // update the UI text with the cell data
            //someTextText.text = "Mode " + (data.indexStage + 1).ToString();
        }
    }
}