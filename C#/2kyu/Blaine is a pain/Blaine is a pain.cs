using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

//ohh how much suffering this kata brought me, but in the end it was cool!
//https://www.codewars.com/kata/59b47ff18bcb77a4d1000076

public class Dinglemouse
{
    static int  Result;
    public static int TrainCrash(string track, string aTrain, int aTrainPos, string bTrain, int bTrainPos, int limit)
        {
          Console.WriteLine(track + "|"+aTrain + "|"+bTrain+ "|"+aTrainPos + "|"+bTrainPos + "|"+limit + "|");
          Game game = new Game(track, new string[] { aTrain, bTrain }, new int[] { aTrainPos, bTrainPos }, 2,MakeResult);
          game.Start(limit);
         return Result;
        }   
    public static void MakeResult(int x) => Result = x;

}
public class Train//Класс определяющий поезд
    {
        public string TrainStr { get; }//Текстовое представление поезда
        public int TrainLength { get; set; }//Длина поезда 
        public char Symbol { get; set; }//Символ поезда

        public int Position { get; set; }//Позиция главного вагона поезда
        public List<string> TrainMap = new List<string>();//Карта расположения поезда(для определения столкновений поездов)

        
        public RotationMove Rotation { get; set; }//Направление движения поезда(определяется по карте, хотя на самом деле всегда одно, так как это задел на будущее с расчетом на создание развилок)
        public int Xpos = 0;//Позиция поезда по X
        public int Ypos = 0;//Позиция поезда по Y

        public RotationMove RotationEnd { get; set; }//Направление хвоста поезда
        public int Xpos_End = 0;//Позиция хвоста поезда по X
        public int Ypos_End = 0;//Позиция хвоста поезда по Y

        public int Stopping;//Количество тиков на которое остановится поезд(Изменяется по мере прохождения тиков)
        public bool IsStopped { get; set; }//Остановлен ли поезд
        public bool IsExpress = false;//Является ли поезд экспрессом
        public bool IsInversed { get; set; }

        
        public void StartStoping()//Остановка поезда
        {
            Stopping = TrainStr.Length - 1;
            IsStopped = true;
        }
        public void StopStopping()//Старт поезда после остановки
        {
            Stopping = 0;
            IsStopped = false;
        }
        public Train(string a, int pos, int y, int x)//Конструктор класса
        {
            IsStopped = false;
            TrainStr = a; //Задание текстового представления поезда
            Position = pos; //Начальная позиция поезда
            Rotation = RotationMove.Right;//Стартовое направление поезда(всегда по часовой стрелке)
            TrainLength = a.Length;//Определение всей длины поезда
            IsExpress = a.ToUpper()[0] == 'X';//Определение экспресс ли это
            Symbol = a.ToUpper()[0];

            IsInversed = a.ToUpper()[0] == a[0];

            string temp = string.Empty;
            for (int i = 0; i < y; i++)//Инициализация пустой карты поезда
            {
                for (int j = 0; j < x; j++)
                {
                    temp += " ";
                }
                TrainMap.Add(temp);
                temp = string.Empty;
            }

        }
        public RotationMove GetInversedMove(RotationMove _rotation)//Возврат обратного направления
        {
            RotationMove temp = RotationMove.UP;

            switch (_rotation)
            {
                case RotationMove.UP:
                    temp = RotationMove.Down;
                    break;
                case RotationMove.Down:
                    temp = RotationMove.UP;
                    break;
                case RotationMove.Left:
                    temp = RotationMove.Right;
                    break;
                case RotationMove.Right:
                    temp = RotationMove.Left;
                    break;
                case RotationMove.UpRight:
                    temp = RotationMove.DownLeft;
                    break;
                case RotationMove.UpLeft:
                    temp = RotationMove.DownRight;
                    break;
                case RotationMove.DownRight:
                    temp = RotationMove.UpLeft;
                    break;
                case RotationMove.DownLeft:
                    temp = RotationMove.UpRight;
                    break;
            }
            return temp;
        }
    }
    public enum RotationMove//Виды направлений движения поезда
    {
        UP,
        Down,
        Left,
        Right,
        UpRight,
        UpLeft,
        DownRight,
        DownLeft
    }

     public class Game
    {
        private int Result = 0;
        private List<string> lvlmap = new List<string>();//Карта уровня
        private List<string> PrinterMap = new List<string>();//Карта для отрисовки(получается при помощи совмещения карт поездов и лвл)

        private List<Train> Trains = new List<Train>();//Абсолютно все поезда перемещающиеся по карте

        private int StartPosition;//Стартовая позиция(по оси X)
        private bool NOTStarted = false;
        public delegate void Message(int x);//Делегат и событие для сообщений о столкновнии, и других действиях поездов если понадобится
        private event Message Cabum;

        /// <summary>
        /// Количество поездов должно совпадать с оным в текстовом представлении и позиционном, или же быть меньше
        /// Так же количество строк поездов, должно соответствовать позициям
        /// Трек(карта) должен(а) быть цикличным(ой)(может иметь произвольное количество самопересечений)
        /// </summary>
        /// <param name="map">Карта хранимая в виде строки с разделителями '\n'</param>
        /// <param name="TrStr">Поезда в виде строк, буква в верхнем регистре указывает на главный вагон</param>
        /// <param name="TrPos">Начальные позиции поездов</param>
        /// <param name="CountTrains">количество поездов</param>
        public Game(string map, string[] TrStr, int[] TrPos, int CountTrains,Message events)//Конструктор класса
        {
            AppointEvent(events);
            //--Карта--//
            int LengthMass = 0;
            int LengthMassMax = 0;
            foreach (var item in map)
            {
                LengthMass++;
                if(item == '\n')//Разделитель строк
                {
                    if(LengthMass>LengthMassMax)
                        LengthMassMax = LengthMass;

                    LengthMass = 0;
                }
            }
            string temp = " ";
            foreach (var item in map)//Разложение карты в одну строку на List со строками
            { 
                if (item == '\n')//Разделитель строк
                {
                    if (temp.Length < LengthMassMax)
                        for (int i = temp.Length; i < LengthMassMax; i++)
                        {
                            temp += " ";
                        }
                    temp += item;
                    lvlmap.Add(temp);
                    PrinterMap.Add(temp);
                    temp = " ";//Сдвиг карты на блок вправо, что-бы было пустое пространство
                    continue;
                }
                temp += item;
            }
          if (temp.Length < LengthMassMax)
                        for (int i = temp.Length; i < LengthMassMax; i++)
                        {
                            temp += " ";
                        }
            lvlmap.Add(temp);//Добавление последней строки 
            PrinterMap.Add(temp);
            
            //--Карта--//
            //--Поезда--//
            for (int i = 0; i < CountTrains; i++)
            {
                Trains.Add(new Train(TrStr[i], TrPos[i], lvlmap.Count, lvlmap[0].Length));//Создание поезда
            }
            //--Поезда--//
            SearchStartPosition();//Нахождение стартовой позиции -  Самый Левый-Верхний элеминт рельс

            //--Инициализация поездов--//
            foreach (var item in Trains)//Установка поездов в точку 0
            {
                item.Xpos = StartPosition;
                InitTrain(item);
            }  

            /*Console.WriteLine("Инициализация завершена:");//
            foreach (var item in Trains)
            {
                Console.WriteLine($"Поезд:{item.TrainStr}; X:{item.Xpos}; Y{item.Ypos};");
            }*/
            UpdatePrintMap();
            //PrintMap();
            if (IsCabum(0))
            {
                NOTStarted = true;
            }
        }
        public void AppointEvent(Message EventMark)//Подписка на событие
        {
            Cabum += EventMark;
        }
        public void AppointEventRev(Message EventMark)//Отписка от события
        {
            Cabum -= EventMark;
        }
        private void SearchStartPosition()//Определение стартовой позиции
        {
            for (int i = 0; i < lvlmap[0].Length; i++)
            {
                if (lvlmap[0][i] == '/')//Нахождение левой верхней поворотной рельсы
                {
                    StartPosition = i;//Присваивание стартовой позиции по X
                    break;
                }
            }
        }
        private void UpdatePrintMap()//Обновление карты 
        {
            string mapPath = string.Empty;
            foreach (var train in Trains)//Обновление состояний поездов
            {
                                
                    if (!train.IsStopped && train.TrainMap[train.Ypos][train.Xpos] != ' ')
                    {
                        Cabum.Invoke(Result);
                        NOTStarted = true;
                        return;
                    }
                for (int i = 0; i < train.TrainMap.Count; i++)
                {
                    for (int j = 0; j < train.TrainMap[i].Length; j++)
                    {
                        if (i == train.Ypos && j == train.Xpos)
                            mapPath += train.Symbol;
                        else
                            mapPath += train.TrainMap[i][j];
                    }
                    train.TrainMap[i] = mapPath;
                    mapPath = string.Empty;
                }
            }

            List<string> tempList = new List<string>();
            string tempstr = string.Empty;
            foreach (var item in PrinterMap)
            {
                for (int i = 0; i < PrinterMap[0].Length; i++)
                {
                    tempstr += ' ';
                }
                tempList.Add(tempstr);
                tempstr = string.Empty;
            }


            foreach (var train in Trains)//Обновление Карты для отрисовки -- Добавить ещё обновление для хвоста поезда
            {
                for (int i = 0; i < PrinterMap.Count; i++)
                {
                    for (int j = 0; j < PrinterMap[i].Length; j++)
                    {
                        if (train.TrainMap[i][j] != ' ')
                           mapPath += train.TrainMap[i][j];
                        else
                           mapPath += tempList[i][j];
                    }
                    tempList[i] = mapPath;
                    mapPath = string.Empty;
                }
            }


            PrinterMap.Clear();
                for (int i = 0; i < tempList.Count; i++)
                {
                    for (int j = 0; j < tempList[i].Length; j++)
                    {
                        //Console.WriteLine($"{i}/{PrinterMap.Count}|{j}/{PrinterMap[i].Length}");
                        if (tempList[i][j] != ' ')
                            mapPath += tempList[i][j];
                        else
                            mapPath += lvlmap[i][j];
                    }
                    PrinterMap.Add(mapPath);
                    mapPath = string.Empty;
                }
        }
        public void PrintMap()//Отрисовка карты в консоли
        {
            Console.SetCursorPosition(0, 0);//Установка курсора в начале консоли, что-бы перерисовывать консоль и производить плавное обновление, а не дёрганное
            foreach (var item in PrinterMap)//Проход по всем строкам 
            {
                Console.Write(item);//Их печать
            }
        }
        public void Start(int limit)
        {
            if (NOTStarted) return;
            Console.CursorVisible = false;
            string mapPath = string.Empty;
            for (int i = 1; i <= limit; i++)
            {
                Result = i;
                if (NOTStarted) return;

                foreach (var trainF in Trains)
                {
                    if (trainF.Stopping > 0)//Проход времени остановки
                    {
                        trainF.Stopping--;
                        continue;
                    }
                    
                        
                    for (int j = 0; j < trainF.TrainMap[trainF.Ypos].Length; j++)//Новый хвостовой символ
                    {
                        if (j == trainF.Xpos)
                            mapPath += trainF.Symbol.ToString().ToLower();
                        else
                            mapPath += trainF.TrainMap[trainF.Ypos][j];
                    }
                    trainF.TrainMap[trainF.Ypos] = mapPath;
                    mapPath = string.Empty;
                    Move(trainF,false);


                    for (int j = 0; j < trainF.TrainMap[trainF.Ypos_End].Length; j++)//Стирание хвостового символа
                    {
                        if (j == trainF.Xpos_End)
                            mapPath += ' ';
                        else
                            mapPath += trainF.TrainMap[trainF.Ypos_End][j];
                    }

                    trainF.TrainMap[trainF.Ypos_End] = mapPath;
                    mapPath = string.Empty;
                    EndMove(trainF);

                  
                    if(!trainF.IsExpress && lvlmap[trainF.Ypos][trainF.Xpos] == 'S')//Остановиться на станции
                    {
                        trainF.StartStoping();
                    }
                }
                
                //Thread.Sleep(400);
                UpdatePrintMap();
                //PrintMap();
                if (IsCabum(i))
                {
                    return;
                }

            }
            Cabum.Invoke(-1);
        }
        private void ChangeRotation(Train trainF)
        {
            switch (trainF.Rotation)
            {
                case RotationMove.UP:
                    if (lvlmap[trainF.Ypos - 1][trainF.Xpos] == '/')//Изменение направления возможно только на 1 у.е (чуть правее/чуть левее)
                        trainF.Rotation = RotationMove.UpRight;
                    else if (lvlmap[trainF.Ypos - 1][trainF.Xpos] == '\\')
                        trainF.Rotation = RotationMove.UpLeft;
                    break;

                case RotationMove.Down:
                    if (lvlmap[trainF.Ypos + 1][trainF.Xpos] == '/')//Изменение направления возможно только на 1 у.е (чуть правее/чуть левее)
                        trainF.Rotation = RotationMove.DownLeft;
                    else if (lvlmap[trainF.Ypos + 1][trainF.Xpos] == '\\')
                        trainF.Rotation = RotationMove.DownRight;
                    break;

                case RotationMove.Left:
                    if (lvlmap[trainF.Ypos][trainF.Xpos] == '/')
                        trainF.Rotation = RotationMove.Down;

                    if (lvlmap[trainF.Ypos][trainF.Xpos - 1] == '/')//Изменение направления возможно только на 1 у.е (чуть правее/чуть левее)
                        trainF.Rotation = RotationMove.DownLeft;
                    else if (lvlmap[trainF.Ypos][trainF.Xpos - 1] == '\\')
                        trainF.Rotation = RotationMove.UpLeft;
                    break;

                case RotationMove.Right:
                    if (lvlmap[trainF.Ypos][trainF.Xpos + 1] == '/')//Изменение направления возможно только на 1 у.е (чуть правее/чуть левее)
                        trainF.Rotation = RotationMove.UpRight;
                    else if (lvlmap[trainF.Ypos][trainF.Xpos + 1] == '\\')
                        trainF.Rotation = RotationMove.DownRight;
                    break;

                case RotationMove.UpRight:
                    if (trainF.Xpos < lvlmap[trainF.Ypos].Length - 1 && lvlmap[trainF.Ypos][trainF.Xpos + 1] is '-' or '+' or 'S')//Изменение направления возможно только на 1 у.е (чуть правее/чуть левее)
                        trainF.Rotation = RotationMove.Right;
                    else if (trainF.Ypos != 0  && lvlmap[trainF.Ypos - 1][trainF.Xpos] is '|' or '+' or 'S')
                        trainF.Rotation = RotationMove.UP;
                    break;

                case RotationMove.UpLeft:
                    if (trainF.Xpos != 0 && lvlmap[trainF.Ypos][trainF.Xpos - 1] is '-' or '+' or 'S')//Изменение направления возможно только на 1 у.е (чуть правее/чуть левее)
                        trainF.Rotation = RotationMove.Left;
                    else if (trainF.Ypos != 0 && lvlmap[trainF.Ypos - 1][trainF.Xpos] is '|' or '+' or 'S')
                        trainF.Rotation = RotationMove.UP;
                    break;

                case RotationMove.DownRight:
                    if (trainF.Xpos < lvlmap[trainF.Ypos].Length - 1 && lvlmap[trainF.Ypos][trainF.Xpos + 1] is '-' or '+' or 'S')//Изменение направления возможно только на 1 у.е (чуть правее/чуть левее)
                        trainF.Rotation = RotationMove.Right;
                    else if (trainF.Ypos < lvlmap.Count -1 && lvlmap[trainF.Ypos + 1][trainF.Xpos] is '|' or '+' or 'S')
                        trainF.Rotation = RotationMove.Down;
                    break;

                case RotationMove.DownLeft:
                    if (trainF.Xpos != 0 && lvlmap[trainF.Ypos][trainF.Xpos - 1] is '-' or '+' or 'S')//Изменение направления возможно только на 1 у.е (чуть правее/чуть левее)
                        trainF.Rotation = RotationMove.Left;
                    else if (trainF.Ypos < lvlmap.Count - 1 && lvlmap[trainF.Ypos + 1][trainF.Xpos] is '|' or '+' or 'S')
                        trainF.Rotation = RotationMove.Down;
                    break;
            }
        }
        private void Move(Train trainF, bool IsInit)
        {
            bool IsNotMove;
            do
            {
              //Console.WriteLine(trainF.TrainStr+"|"+trainF.Rotation + "|" + trainF.Ypos+"|" + trainF.Xpos);
                IsNotMove = false;
                switch (trainF.Rotation)
                {
                    case RotationMove.UP:
                        if (IsRailway(lvlmap[trainF.Ypos - 1][trainF.Xpos], trainF.Rotation))//Проверка на то рельса ли следующая клетка по направлению движения и подходит ли она
                        {
                            trainF.Ypos--;//Передвижение головы поезда по Y
                            IsNotMove = false;
                        }
                        else
                        {
                            ChangeRotation(trainF);//Изменение поворота
                            IsNotMove = false;//Провести попытку передвижения снова
                            trainF.Ypos--;//Передвижение головы поезда по Y
                        }
                        break;

                    case RotationMove.Down:
                        if (IsRailway(lvlmap[trainF.Ypos + 1][trainF.Xpos], trainF.Rotation))//Проверка на то рельса ли следующая клетка по направлению движения и подходит ли она
                        {
                            trainF.Ypos++;//Передвижение головы поезда по Y
                            IsNotMove = false;
                        }
                        else
                        {
                            ChangeRotation(trainF);//Изменение поворота
                            IsNotMove = false;//Провести попытку передвижения снова
                            trainF.Ypos++;//Передвижение головы поезда по Y
                        }
                        break;

                    case RotationMove.Left:
                        if (trainF.Xpos != 0 && IsRailway(lvlmap[trainF.Ypos][trainF.Xpos - 1], trainF.Rotation))//Проверка на то рельса ли следующая клетка по направлению движения и подходит ли она
                        {
                            trainF.Xpos--;//Передвижение головы поезда по X
                            IsNotMove = false;
                        }
                        else
                        {
                            ChangeRotation(trainF);//Изменение поворота
                            IsNotMove = false;//Провести попытку передвижения снова
                            trainF.Xpos--;//Передвижение головы поезда по X
                        }
                        break;

                    case RotationMove.Right:
                        if (trainF.Xpos != lvlmap[0].Length && IsRailway(lvlmap[trainF.Ypos][trainF.Xpos + 1], trainF.Rotation))//Проверка на то рельса ли следующая клетка по направлению движения и подходит ли она
                        {
                            trainF.Xpos++;//Передвижение головы поезда по X
                            IsNotMove = false;
                        }
                        else
                        {
                            ChangeRotation(trainF);//Изменение поворота
                            IsNotMove = false;//Провести попытку передвижения снова
                            trainF.Xpos++;//Передвижение головы поезда по X
                        }
                        break;

                    case RotationMove.UpRight:
                        if ( trainF.Ypos!=0 && IsRailway(lvlmap[trainF.Ypos - 1][trainF.Xpos + 1], trainF.Rotation))//Проверка на то рельса ли следующая клетка по направлению движения и подходит ли она
                        {
                            trainF.Xpos++;//Передвижение головы поезда по X
                            trainF.Ypos--;//Передвижение головы поезда по Y
                            IsNotMove = false;
                        }
                        else
                        {
                            ChangeRotation(trainF);//Изменение поворота
                            IsNotMove = true;//Провести попытку передвижения снова
                        }
                        break;

                    case RotationMove.UpLeft:
                        if (trainF.Ypos != 0 && IsRailway(lvlmap[trainF.Ypos - 1][trainF.Xpos - 1], trainF.Rotation))//Проверка на то рельса ли следующая клетка по направлению движения и подходит ли она
                        {
                            trainF.Xpos--;//Передвижение головы поезда по X
                            trainF.Ypos--;//Передвижение головы поезда по Y
                            IsNotMove = false;
                        }
                        else
                        {
                            ChangeRotation(trainF);//Изменение поворота
                            IsNotMove = true;//Провести попытку передвижения снова
                        }
                        break;

                    case RotationMove.DownRight:
                        if (trainF.Ypos < lvlmap.Count - 1 && trainF.Xpos < lvlmap[0].Length && IsRailway(lvlmap[trainF.Ypos + 1][trainF.Xpos + 1], trainF.Rotation))//Проверка на то рельса ли следующая клетка по направлению движения и подходит ли она
                        {
                            trainF.Xpos++;//Передвижение головы поезда по X
                            trainF.Ypos++;//Передвижение головы поезда по Y
                            IsNotMove = false;
                        }
                        else
                        {
                            ChangeRotation(trainF);//Изменение поворота
                            IsNotMove = true;//Провести попытку передвижения снова
                        }
                        break;

                    case RotationMove.DownLeft:
                        if (trainF.Ypos != lvlmap.Count - 1 && IsRailway(lvlmap[trainF.Ypos + 1][trainF.Xpos - 1], trainF.Rotation))//Проверка на то рельса ли следующая клетка по направлению движения и подходит ли она
                        {
                            trainF.Xpos--;//Передвижение головы поезда по X
                            trainF.Ypos++;//Передвижение головы поезда по Y
                            IsNotMove = false;
                        }
                        else
                        {
                            ChangeRotation(trainF);//Изменение поворота
                            IsNotMove = true;//Провести попытку передвижения снова
                        }
                        break;
                }

            } while (IsNotMove);

            if (!IsInit)//Изменение позиции поезда относительно начала 'трека'
                if (!trainF.IsInversed)
                    trainF.Position++;
                else
                    trainF.Position--;
        }
        private void InitTrain(Train trainF)//Передвижение поезда до его стартовой позиции 
        {
            for (int i = 0; i < trainF.Position; i++)//Доведение до стартовой позиции
                Move(trainF, true);

            if (trainF.IsInversed) trainF.Rotation = trainF.GetInversedMove(trainF.Rotation);//Разворот поезда 
                          if (trainF.Xpos == StartPosition && trainF.Ypos == 0 && trainF.IsInversed) trainF.Rotation = RotationMove.DownLeft;
            InitTrainEnd(trainF);//Инициализация хвоста поезда
        }
        private void InitTrainEnd(Train trainF)
        {
            trainF.RotationEnd = trainF.GetInversedMove(trainF.Rotation);

            trainF.Xpos_End = trainF.Xpos;
            trainF.Ypos_End = trainF.Ypos;
            if (trainF.Xpos_End == StartPosition && trainF.Ypos_End == 0 && !trainF.IsInversed) trainF.RotationEnd = RotationMove.DownLeft;
            else  if (trainF.Xpos_End == StartPosition && trainF.Ypos_End == 0 && trainF.IsInversed) trainF.RotationEnd = RotationMove.UpRight;
            for (int i = 0; i < trainF.TrainLength-1; i++)
            {
                EndMove(trainF);

                    if (trainF.TrainMap[trainF.Ypos_End][trainF.Xpos_End] != ' ')
                    {
                        Cabum.Invoke(0);
                        NOTStarted = true;
                        return;
                    }

               

                string mapPath = string.Empty;

                        for (int j = 0; j < trainF.TrainMap[trainF.Ypos_End].Length; j++)
                        {
                            if (j == trainF.Xpos_End)
                                mapPath += trainF.Symbol.ToString().ToLower();
                            else
                                mapPath += trainF.TrainMap[trainF.Ypos_End][j];
                        }
                        trainF.TrainMap[trainF.Ypos_End] = mapPath;
            }

            trainF.RotationEnd = trainF.GetInversedMove(trainF.RotationEnd);
        }
        private void EndMove(Train trainF)
        {
            bool IsNotMove;
            do
            {
                IsNotMove = false;
                //Console.WriteLine(trainF.TrainStr);
                switch (trainF.RotationEnd)
                {
                    case RotationMove.UP:
                        if(IsRailway(lvlmap[trainF.Ypos_End - 1][trainF.Xpos_End], trainF.RotationEnd))//Проверка на то рельса ли следующая клетка по направлению движения и подходит ли она
                        {
                            trainF.Ypos_End--;//Передвижение головы поезда по Y
                            IsNotMove = false;
                        }
                        else
                        {
                            ChangeRotationEnd(trainF);//Изменение поворота
                            IsNotMove = false;//Провести попытку передвижения снова
                            trainF.Ypos_End--;//Передвижение головы поезда по Y
                        }
                        break;

                    case RotationMove.Down:
                        if (IsRailway(lvlmap[trainF.Ypos_End + 1][trainF.Xpos_End], trainF.RotationEnd))//Проверка на то рельса ли следующая клетка по направлению движения и подходит ли она
                        {
                            trainF.Ypos_End++;//Передвижение головы поезда по Y
                            IsNotMove = false;
                        }
                        else
                        {
                            ChangeRotationEnd(trainF);//Изменение поворота
                            IsNotMove = false;//Провести попытку передвижения снова
                            trainF.Ypos_End++;//Передвижение головы поезда по Y
                        }
                        break;

                    case RotationMove.Left:
                        if (trainF.Xpos_End != 0 && IsRailway(lvlmap[trainF.Ypos_End][trainF.Xpos_End - 1], trainF.RotationEnd))//Проверка на то рельса ли следующая клетка по направлению движения и подходит ли она
                        {
                            trainF.Xpos_End--;//Передвижение головы поезда по X
                            IsNotMove = false;
                        }
                        else
                        {
                            ChangeRotationEnd(trainF);//Изменение поворота
                            IsNotMove = false;//Провести попытку передвижения снова
                            trainF.Xpos_End--;//Передвижение головы поезда по X
                        }
                        break;

                    case RotationMove.Right:
                        if (trainF.Xpos_End != lvlmap[0].Length && IsRailway(lvlmap[trainF.Ypos_End][trainF.Xpos_End + 1], trainF.RotationEnd))//Проверка на то рельса ли следующая клетка по направлению движения и подходит ли она
                        {
                            trainF.Xpos_End++;//Передвижение головы поезда по X
                            IsNotMove = false;
                        }
                        else
                        {
                            ChangeRotationEnd(trainF);//Изменение поворота
                            IsNotMove = false;//Провести попытку передвижения снова
                            trainF.Xpos_End++;//Передвижение головы поезда по X
                        }
                        break;

                    case RotationMove.UpRight:
                        if (trainF.Ypos_End != 0 && IsRailway(lvlmap[trainF.Ypos_End - 1][trainF.Xpos_End + 1], trainF.RotationEnd))//Проверка на то рельса ли следующая клетка по направлению движения и подходит ли она
                        {
                            trainF.Xpos_End++;//Передвижение головы поезда по X
                            trainF.Ypos_End--;//Передвижение головы поезда по Y
                            IsNotMove = false;
                        }
                        else
                        {
                            ChangeRotationEnd(trainF);//Изменение поворота
                            IsNotMove = true;//Провести попытку передвижения снова
                        }
                        break;

                    case RotationMove.UpLeft:
                        if (trainF.Ypos_End != 0 && IsRailway(lvlmap[trainF.Ypos_End - 1][trainF.Xpos_End - 1], trainF.RotationEnd))//Проверка на то рельса ли следующая клетка по направлению движения и подходит ли она
                        {
                            trainF.Xpos_End--;//Передвижение головы поезда по X
                            trainF.Ypos_End--;//Передвижение головы поезда по Y
                            IsNotMove = false;
                        }
                        else
                        {
                            ChangeRotationEnd(trainF);//Изменение поворота
                            IsNotMove = true;//Провести попытку передвижения снова
                        }
                        break;

                    case RotationMove.DownRight:
                        if (trainF.Ypos_End != lvlmap.Count - 1 && IsRailway(lvlmap[trainF.Ypos_End + 1][trainF.Xpos_End + 1], trainF.RotationEnd))//Проверка на то рельса ли следующая клетка по направлению движения и подходит ли она
                        {
                            trainF.Xpos_End++;//Передвижение головы поезда по X
                            trainF.Ypos_End++;//Передвижение головы поезда по Y
                            IsNotMove = false;
                        }
                        else
                        {
                            ChangeRotationEnd(trainF);//Изменение поворота
                            IsNotMove = true;//Провести попытку передвижения снова
                        }
                        break;

                    case RotationMove.DownLeft:
                        if (trainF.Ypos_End != lvlmap.Count - 1 && IsRailway(lvlmap[trainF.Ypos_End + 1][trainF.Xpos_End - 1], trainF.RotationEnd))//Проверка на то рельса ли следующая клетка по направлению движения и подходит ли она
                        {
                            trainF.Xpos_End--;//Передвижение головы поезда по X
                            trainF.Ypos_End++;//Передвижение головы поезда по Y
                            IsNotMove = false;
                        }
                        else
                        {
                            ChangeRotationEnd(trainF);//Изменение поворота
                            IsNotMove = true;//Провести попытку передвижения снова
                        }
                        break;
                }
            }while(IsNotMove);
        }
        private void ChangeRotationEnd(Train trainF)
        {
            switch (trainF.RotationEnd)
            {
                case RotationMove.UP:

                    if (lvlmap[trainF.Ypos_End - 1][trainF.Xpos_End] == '/')//Изменение направления возможно только на 1 у.е (чуть правее/чуть левее)
                        trainF.RotationEnd = RotationMove.UpRight;
                    else if (lvlmap[trainF.Ypos_End - 1][trainF.Xpos_End] == '\\')
                        trainF.RotationEnd = RotationMove.UpLeft;
                    break;

                case RotationMove.Down:
                    if (lvlmap[trainF.Ypos_End + 1][trainF.Xpos_End] == '/')//Изменение направления возможно только на 1 у.е (чуть правее/чуть левее)
                        trainF.RotationEnd = RotationMove.DownLeft;
                    else if (lvlmap[trainF.Ypos_End + 1][trainF.Xpos_End] == '\\')
                        trainF.RotationEnd = RotationMove.DownRight;
                    break;

                case RotationMove.Left:
                    if (lvlmap[trainF.Ypos_End][trainF.Xpos_End] == '/')
                        trainF.RotationEnd = RotationMove.Down;

                    if (lvlmap[trainF.Ypos_End][trainF.Xpos_End - 1] == '/')//Изменение направления возможно только на 1 у.е (чуть правее/чуть левее)
                        trainF.RotationEnd = RotationMove.DownLeft;
                    else if (lvlmap[trainF.Ypos_End][trainF.Xpos_End - 1] == '\\')
                        trainF.RotationEnd = RotationMove.UpLeft;
                    break;

                case RotationMove.Right:
                    if (Result == 0 && trainF.Ypos_End == 0 && trainF.Xpos_End == StartPosition)
                    {
                        if (lvlmap[trainF.Ypos_End][trainF.Xpos_End] == '/' && trainF.Rotation == RotationMove.Right)
                            trainF.RotationEnd = RotationMove.Down;
                        else if (lvlmap[trainF.Ypos_End][trainF.Xpos_End] == '/' && trainF.Rotation == RotationMove.Left)
                            trainF.RotationEnd = RotationMove.Right;
                    }

                    if (lvlmap[trainF.Ypos_End][trainF.Xpos_End + 1] == '/')//Изменение направления возможно только на 1 у.е (чуть правее/чуть левее)
                        trainF.RotationEnd = RotationMove.UpRight;
                    else if (lvlmap[trainF.Ypos_End][trainF.Xpos_End + 1] == '\\')
                        trainF.RotationEnd = RotationMove.DownRight;
                    break;

                case RotationMove.UpRight:
                    if (trainF.Xpos_End < lvlmap[trainF.Ypos_End].Length - 1 && lvlmap[trainF.Ypos_End][trainF.Xpos_End + 1] is '-' or '+' or 'S')//Изменение направления возможно только на 1 у.е (чуть правее/чуть левее)
                        trainF.RotationEnd = RotationMove.Right;
                    else if (trainF.Ypos_End != 0 && lvlmap[trainF.Ypos_End - 1][trainF.Xpos_End] is '|' or '+' or 'S')
                        trainF.RotationEnd = RotationMove.UP;
                    break;

                case RotationMove.UpLeft:
                    if (trainF.Xpos_End != 0 && lvlmap[trainF.Ypos_End][trainF.Xpos_End - 1] is '-' or '+' or 'S')//Изменение направления возможно только на 1 у.е (чуть правее/чуть левее)
                        trainF.RotationEnd = RotationMove.Left;
                    else if (trainF.Ypos_End != 0 && lvlmap[trainF.Ypos_End - 1][trainF.Xpos_End] is '|' or '+' or 'S')
                        trainF.RotationEnd = RotationMove.UP;
                    break;

                case RotationMove.DownRight:
                    if (trainF.Xpos_End < lvlmap[trainF.Ypos_End].Length - 1 && lvlmap[trainF.Ypos_End][trainF.Xpos_End + 1] is '-' or '+' or 'S')//Изменение направления возможно только на 1 у.е (чуть правее/чуть левее)
                        trainF.RotationEnd = RotationMove.Right;
                    else if (trainF.Ypos_End < lvlmap.Count && lvlmap[trainF.Ypos_End + 1][trainF.Xpos_End] is '|' or '+' or 'S')
                        trainF.RotationEnd = RotationMove.Down;
                    break;

                case RotationMove.DownLeft:
                    if (trainF.Xpos_End != 0 && lvlmap[trainF.Ypos_End][trainF.Xpos_End - 1] is '-' or '+' or 'S')//Изменение направления возможно только на 1 у.е (чуть правее/чуть левее)
                        trainF.RotationEnd = RotationMove.Left;
                    else if (trainF.Ypos_End < lvlmap.Count && lvlmap[trainF.Ypos_End + 1][trainF.Xpos_End] is '|' or '+' or 'S')
                        trainF.RotationEnd = RotationMove.Down;
                    break;
            }
        }
        private bool IsRailway(char s, RotationMove rot)//Проверка можем ли мы ехать дальше в том направлении
        {
            switch (rot)
            {
                case RotationMove.UP:
                    return s is '|' or '+' or 'S'; //Все виды рельс на которые мы сможем встать

                case RotationMove.Down:
                    return s is '|' or '+' or 'S';//Все виды рельс на которые мы сможем встать

                case RotationMove.Left:
                    return s is '-' or '+' or 'S';//Все виды рельс на которые мы сможем встать

                case RotationMove.Right:
                    return s is '-' or '+' or 'S';//Все виды рельс на которые мы сможем встать

                case RotationMove.UpRight:
                    return s is '/' or 'X' or 'S';//Все виды рельс на которые мы сможем встать

                case RotationMove.UpLeft:
                    return s is '\\' or 'X' or 'S';//Все виды рельс на которые мы сможем встать

                case RotationMove.DownRight:
                    return s is '\\' or 'X' or 'S';//Все виды рельс на которые мы сможем встать

                case RotationMove.DownLeft:
                    return s is '/' or 'X' or 'S';//Все виды рельс на которые мы сможем встать
            }
            return false;
        }
        private bool IsCabum(int a)
        {
            foreach (var item in Trains)
            {
                foreach (var item2 in Trains)
                {
                    if (item2 == item) continue;

                    for (int i = 0; i < item.TrainMap.Count; i++)
                    {
                        for (int j = 0; j < item.TrainMap[0].Length; j++)
                        {
                            if (item.TrainMap[i][j] != ' ' && item2.TrainMap[i][j] != ' ')
                            {
                                Cabum.Invoke(a);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }