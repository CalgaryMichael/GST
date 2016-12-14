﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GST_Program.Models {
	public class TreeAlgorithm {
		//a class to represent a point with an angle
		public class point {
			public int pos_x;
			public int pos_y;
			public int angle;

			public point(int posx, int posy) {
				pos_x = posx;
				pos_y = posy;
				angle = 0;
			}
			public point(int posx, int posy, int angl) {
				pos_x = posx;
				pos_y = posy;
				angle = angl;
			}
		}

		//Obtains percentage across the tree based on the leaf quantity number
		static public float BinPercent(int num) {
			float percent = 0.0f;
			int loopcount = 0;
			for (int i = 1; i <= num; i *= 2) {
				int compare = num & i;
				if (compare != 0) {
					percent += (0.5f / (float)Math.Pow(2, loopcount));
				}
				loopcount++;
			}
			return percent;
		}

		//finds the position of a point based on the shape it's strewn across and the percentage across the shape
		static point ShapePos(List<point> shape, float percent, float offset) {
			List<float> lengths = new List<float>();
			lengths.Add(0.0f);
			for (int i = 0; i < shape.Count - 1; i++) {
				float length = ((float)Math.Sqrt((float)Math.Pow(Math.Abs((float)shape[i].pos_x - (float)shape[i + 1].pos_x), 2) +
					(float)Math.Pow(Math.Abs((float)shape[i].pos_y - (float)shape[i + 1].pos_y), 2)));
				lengths.Add(lengths[i] + length);
			}

			float place = percent * lengths[lengths.Count - 1];
			float percent2 = 0.0f;
			bool found = false;
			point p1, p2, newpt;
			for (int i = 0; i < lengths.Count - 1 && !found; i++) {
				if (place <= lengths[i + 1]) {
					found = true;
					p1 = shape[i];
					p2 = shape[i + 1];
					percent2 = (place - lengths[i]) / (lengths[i + 1] - lengths[i]);

					newpt = new point((int)((p2.pos_x - p1.pos_x) * percent2) + p1.pos_x,
						(int)((p2.pos_y - p1.pos_y) * percent2) + p1.pos_y,
						(int)Math.Round(Math.Atan2(p2.pos_y - p1.pos_y, p2.pos_x - p1.pos_x) * 180.0 / Math.PI, 0));

					newpt.pos_x += (int)(offset * Math.Round((Math.Sin(newpt.angle / 180.0 * Math.PI)), 5) * -1);
					newpt.pos_y += (int)(offset * Math.Round((Math.Cos(newpt.angle / 180.0 * Math.PI)), 5));

					return newpt;
				}
			}
			return null;
		}

		//Finds a leaf's position on the Tree Image
		static public point TreePos(float percent, float offset) {

			//The entire tree image, hard-coded
			List<point> treeShape = new List<point>();
			treeShape.Add(new point(200, 500));
			treeShape.Add(new point(350, 369));
			treeShape.Add(new point(242, 397));
			treeShape.Add(new point(101, 382));
			treeShape.Add(new point(242, 369));
			treeShape.Add(new point(345, 330));
			treeShape.Add(new point(248, 264));
			treeShape.Add(new point(177, 270));
			treeShape.Add(new point(98, 227));
			treeShape.Add(new point(183, 240));
			treeShape.Add(new point(245, 237));
			treeShape.Add(new point(344, 290));
			treeShape.Add(new point(270, 171));
			treeShape.Add(new point(255, 55));
			treeShape.Add(new point(300, 163));
			treeShape.Add(new point(368, 260));
			treeShape.Add(new point(399, 151));
			treeShape.Add(new point(392, 18));
			treeShape.Add(new point(426, 135));
			treeShape.Add(new point(411, 264));
			treeShape.Add(new point(472, 133));
			treeShape.Add(new point(536, 64));
			treeShape.Add(new point(488, 152));
			treeShape.Add(new point(441, 292));
			treeShape.Add(new point(518, 279));
			treeShape.Add(new point(574, 219));
			treeShape.Add(new point(688, 194));
			treeShape.Add(new point(588, 242));
			treeShape.Add(new point(534, 301));
			treeShape.Add(new point(441, 333));
			treeShape.Add(new point(550, 360));
			treeShape.Add(new point(697, 328));
			treeShape.Add(new point(560, 388));
			treeShape.Add(new point(437, 373));

			point treePoint = ShapePos(treeShape, percent, offset);

			return treePoint;
		}
	}
}