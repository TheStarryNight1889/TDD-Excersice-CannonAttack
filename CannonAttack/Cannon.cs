using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CannonAttack
{
    public class Cannon
    {
        public static int SPEED_OF_LIGHT = 299792458;
        public static int MAX_ANGLE = 90;
        public static int MAX_TARGET_DISTANCE = 20000;
        public static int MIN_TARGET_DISTANCE = 1;
        public static int HIT_RANGE = 50;
        public Player Player { get; set; }
        public int Angle { get; set; }
        public int Speed { get; set; }
        public int TargetDistance { get; set; }

        public Cannon(Player player)
        {
            this.Player = player;
            this.TargetDistance = new Random().Next(MIN_TARGET_DISTANCE, MAX_TARGET_DISTANCE);
        }
        public bool SetSpeed(int speed)
        {
            if (speed <= SPEED_OF_LIGHT)
            {
                this.Speed = speed;
                return true;
            }
            else
                return false;
        }
        public bool SetAngle(int angle)
        {
            if (angle <= MAX_ANGLE)
            {
                this.Angle = angle;
                return true;
            }
            else
                return false;
        }
        public bool SetTargetDistance(int distance)
        {
            if (distance > MIN_TARGET_DISTANCE && distance < MAX_TARGET_DISTANCE)
            {
                this.TargetDistance = distance;
                return true;
            }
            else
                return false;
        }
        public bool HitTarget()
        {
            int time = 0;
            double height = 0;
            double distance = 0;
            double angleInRadians = (3.1415926536 / 180) * this.Angle;
            while (height >= 0)
            {
                time++;
                distance = this.Speed * Math.Cos(angleInRadians) * time;
                height = (this.Speed * Math.Sin(angleInRadians) * time) - ( /* GRAVITY */9.8 * Math.Pow(time, 2)) / 2;
            }

            if (Enumerable.Range(TargetDistance - HIT_RANGE, TargetDistance + HIT_RANGE).Contains(Convert.ToInt32(distance)))
            {
                return true;
            }
            else
                return false;
        }

    }
}
