using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class TimeRecorderWindow : EditorWindow , IHasCustomMenu{

    /// <summary> Seconds </summary>
    private const double repaintInterval = 2;
    private static DateTime nextRepaint;

    private static DateTime selectedDate;

    [MenuItem("Window/Meaf75/Time recorder")]
    static void Init(){
        // Get existing open window or if none, make a new one:
        var window = (TimeRecorderWindow) GetWindow(typeof(TimeRecorderWindow));
        window.titleContent = new GUIContent("Time recorder");

        selectedDate = DateTime.Now;

//        window.Show();

        Debug.Log($"Llamadox [{window.name}] ");

    }

    private void OnEnable(){
        selectedDate = DateTime.Now;
        DrawWindow();
    }

    /// <summary> Repaint window & excecute TimeRecoder logic here instead of EditorApplication.update while window is open </summary>
//    private void Update(){
//
//        var currentTime = DateTime.Now;
//
//        // Debug.Log($"{nextRefresh} vs {currentTime} = {nextRefresh < currentTime}");
//
//        // Repaint window
//        if(nextRepaint < currentTime){
//            // Update countdown
////                Debug.Log("voy a repintar");
//            nextRepaint = currentTime.AddSeconds(repaintInterval);
//            Repaint();
//        }
//    }

    // This interface implementation is automatically called by Unity.
    void IHasCustomMenu.AddItemsToMenu(GenericMenu menu){
        GUIContent content = new GUIContent("Repintar");
        menu.AddItem(content, false, RepaintWindow);
    }

    private void DrawWindow(){

        VisualElement root = rootVisualElement;
        var window = (TimeRecorderWindow) GetWindow(typeof(TimeRecorderWindow));

        var timeRecorderTemplate = Resources.Load<VisualTreeAsset>("TimeRecorderTemplate");
        var timeRecorderTemplateStyle = Resources.Load<StyleSheet>("TimeRecorderTemplateStyle");
        root.styleSheets.Add(timeRecorderTemplateStyle);

        var dayElementTemplate = Resources.Load<VisualTreeAsset>("DayContainerTemplate");
        var dayElementTemplateStyle = Resources.Load<StyleSheet>("DayContainerTemplateStyle");
        root.styleSheets.Add(dayElementTemplateStyle);

        // Add tree to root element
        timeRecorderTemplate.CloneTree(root);

        // Update date label
        var dateLabel = root.Q<Label>("label-date");
        dateLabel.text = $"{selectedDate.Day}-{selectedDate.Month}-{selectedDate.Year}";

        // Fix buttons action
        var prevMonthBtn = root.Q<Button>("btn-prev-month");
        var nextMonthBtn = root.Q<Button>("btn-next-month");

        prevMonthBtn.clicked += () => ChangeMonthOffset(-1);
        nextMonthBtn.clicked += () => ChangeMonthOffset(1);

        // Generate days
        var daysContainer = root.Q<VisualElement>("days-container");

        int numberOfDays = DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month);

        for(int i = 0; i < numberOfDays; i++){
            var dayElement = dayElementTemplate.CloneTree();

            var dayLabel = dayElement.Q<Label>("label-day");
            dayLabel.text = $"{i+1}";

            var hoursLabel = dayElement.Q<Label>("label-hours");
//            hoursLabel.text = $"{1}h";

            daysContainer.Add(dayElement);
        }
    }

    /// <summary> Change month  </summary>
    /// <param name="offset">-1 or 1</param>
    void ChangeMonthOffset(int offset){
        selectedDate = selectedDate.AddMonths(offset);
        RepaintWindow();
    }

    private void RepaintWindow(){
        Debug.Log("Repainteando");
        VisualElement root = rootVisualElement;
        root.Clear();
        DrawWindow();
    }

}
