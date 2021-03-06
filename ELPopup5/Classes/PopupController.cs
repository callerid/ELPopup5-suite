﻿using ELPopup5;
using ELPopup5.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace cid_cm.Classes
{
    public class PopupController
    {
        public static int popups = 0;
        public const int popupHeight = 56;
        public List<FrmPopup> PopupsList;
        public string Number = "";
        public bool[] PosIsTaken;
        public int[] PosY;
        public List<string> RepeatCheckingList;
        public Form previousActiveForm;
        public Control previousFocusedControl;

        public PopupController()
        {
            popups = 0;
            PopupsList = new List<FrmPopup>();
            RepeatCheckingList = new List<string>();

            PosIsTaken = new bool[20];
            PosIsTaken[0] = false;
            PosIsTaken[1] = false;
            PosIsTaken[2] = false;
            PosIsTaken[3] = false;
            PosIsTaken[4] = false;
            PosIsTaken[5] = false;
            PosIsTaken[6] = false;
            PosIsTaken[7] = false;
            PosIsTaken[8] = false;
            PosIsTaken[9] = false;
            PosIsTaken[10] = false;
            PosIsTaken[11] = false;
            PosIsTaken[12] = false;
            PosIsTaken[13] = false;
            PosIsTaken[14] = false;
            PosIsTaken[15] = false;
            PosIsTaken[16] = false;
            PosIsTaken[17] = false;
            PosIsTaken[18] = false;
            PosIsTaken[19] = false;

            PosY = new int[20];
            PosY[0] = 0;
            PosY[1] = popupHeight * 1;
            PosY[2] = popupHeight * 2;
            PosY[3] = popupHeight * 3;
            PosY[4] = popupHeight * 4;
            PosY[5] = popupHeight * 5;
            PosY[6] = popupHeight * 6;
            PosY[7] = popupHeight * 7;
            PosY[8] = popupHeight * 8;
            PosY[9] = popupHeight * 9;
            PosY[10] = popupHeight * 10;
            PosY[11] = popupHeight * 11;
            PosY[12] = popupHeight * 12;
            PosY[13] = popupHeight * 13;
            PosY[14] = popupHeight * 14;
            PosY[15] = popupHeight * 15;
            PosY[16] = popupHeight * 16;
            PosY[17] = popupHeight * 17;
            PosY[18] = popupHeight * 18;
            PosY[19] = popupHeight * 19;

        }

        public void AddPopup(int line, bool isInbound, string num, string name)
        {

            if (!bool.Parse(Program.AppSettings[(int)Program.AppSetting.POPUP_INBOUND]) && isInbound) return;
            if (!bool.Parse(Program.AppSettings[(int)Program.AppSetting.POPUP_OUTBOUND]) && !isInbound) return;

            var uString = line + " " + (isInbound ? "1" : "0") + " " + num + " " + name;
            if (!RepeatCheckingList.Contains(uString))
            {
                RepeatCheckingList.Add(uString);
            }
            else
            {
                return;
            }

            if (popups > 14) return;

            Random r = new Random();
            int uId = r.Next(0, 10000);

            var position = 0;
            foreach (var pos in PosIsTaken)
            {
                if (pos)
                {
                    position++;
                    continue;
                }

                break;
            }

            PopupsList.Add(new FrmPopup(uId, line, isInbound, num, name, 0, PosY[position], position, uString));
            PosIsTaken[position] = true;

            var activeForm = Form.ActiveForm;
            var focusedControl = Common.FindFocusedControl(activeForm);

            PopupsList[PopupsList.Count - 1].Show();

            popups++;

            OrderPopups();

            foreach (FrmPopup p in PopupsList)
            {
                p.WindowState = FormWindowState.Normal;
            }

            if (activeForm == null) return;
            activeForm.Activate();
            activeForm.Focus();

            if(focusedControl != null) focusedControl.Focus();

        }

        public void RemovePopup(int id)
        {
            var cnt = 0;
            var index = -1;
            foreach (var p in PopupsList)
            {
                if (p.ID == id)
                {
                    index = cnt;
                    PosIsTaken[p.POS] = false;
                    if (RepeatCheckingList.Contains(p.USTRING)) RepeatCheckingList.Remove(p.USTRING);
                }
                cnt++;
            }

            if (index > -1)
            {
                PopupsList.RemoveAt(index);
                popups--;
            }
        }

        public void RemovePopup(string uString)
        {
            var cnt = 0;
            var index = -1;
            foreach (var p in PopupsList)
            {
                if (p.USTRING == uString)
                {
                    index = cnt;
                    PosIsTaken[p.POS] = false;
                    if (RepeatCheckingList.Contains(p.USTRING)) RepeatCheckingList.Remove(p.USTRING);
                }
                cnt++;
            }

            if (index > -1)
            {
                PopupsList.RemoveAt(index);
                popups--;
            }

        }

        private void OrderPopups()
        {
            SortedList<int, int> PopupIDs = new SortedList<int, int>();
            foreach(FrmPopup popup in PopupsList)
            {
                try
                {
                    PopupIDs.Add(popup.LineNumber, popup.ID);
                }
                catch(ArgumentException ex)
                {
                    Console.Write("Already in list: " + ex.ToString());
                }
            }
            
            // Popup ID's are now ordered by line number
            int pos = 0;
            foreach(int line_number in PopupIDs.Keys)
            {

                int index = GetIndexOfPopupWithID(PopupIDs[line_number]);

                if (index == -1) continue;

                PopupsList[index].Reposition(0, PosY[pos]);

                pos++;

            }

        }

        private int GetIndexOfPopupWithID(int id)
        {
            int index = 0;
            foreach(FrmPopup popup in PopupsList)
            {
                if (popup.ID == id) return index;
                index++;
            }
            return -1;
        }
    }
}
