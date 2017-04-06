using UnityEngine;
using System.Collections;
using System.IO;

/*
 * Ball objects
 * 	industuctable
 * 	contains monster
 * 	contains angry monster
 * 	normal
 * 	explosive
 * 	lava
 * 
 * Crystals
 * 	Diamond -white
 * 	Emeralds -green
 * 	Saphires -blue
 * 	Rubys -red
 * 	Amethist - yellow?
 * 	Quartz - purple?
 * 	Add sparkles
 * 
 * Add manual shadows
 * add smoke to lava
 * 
 * 
 * Ore
 * 	Gold
 * 	Silver
 * 	Copper
 * 	Iron?
 * 	Platnum?
 * 	Uranium?
 * 	Add sparkles?
 * 
 * Balloon rock
 * 	radioactive, floats up
 * 
 * Liquid
 * 	lava
 * 	radioactive
 * 	chemical
 * 	oil
 * 	water
 * 	mud
 *  alive ameoba
 * 
 * maybe liquids only come up half or quarter of the way or even on the floor, maybe the begin to fill up from the floor up and then begin to spread out
 * so a lava creature can exist in the liquid and then the player could also drive in the liquid slowly or with damage over time, need special equipment/shields to drive in it, snorkle, lava proof or radioactive proof
 * 
 * Filled Block
 * 	industructable
 * 	Light dirt
 * 	Medium dirt
 * 	heavy dirt
 *  Black dirt
 * 	normal rock
 * 	lava
 * 	radioactive
 * 	
 * Moveable block
 * 	industructable
 * 	normal rock
 * 	lava
 * 	radioactive
 *  explosive
 * 
 * Monster
 * 	Rock monster
 * 	Angry rock monster
 * 	explosive rock monster
 * 	radioactive rock monster
 * 
 * 	right wall follow
 * 	left wall follow
 * 	random motion
 * 	random motion until run into wall
 * 	fast, medium, slow
 * 
 * shoot/drill
 * 	Block -> moveable block -> ball 
 * 
 * Pipe
 * holds rocks, crystals, ore, round things, allow player inside? how to make flow around corner?
 * some with holes, some without holes, textures bumpy, smooth, rusty, cement, clay, labels (radioactive, corrosive)? different metals? Allow liquids?
 * transformation pipes, objects of any kind go in, only certain objects come out.
 * 
 * Exit (next level, number of points needed to open, cannot have stuff pushed onto it or stuff pushed onto it disappears)
 * 
 * Entrance, spawn point, that cannot have stuff pushed onto it or stuff pushed onto it disappears, could have more than one entrace and exit spawn point
 * 
 * Explosives (push around on playfield or just drop an explode, shoot with laser to explode, just use explosive rocks?)
 * 
 * Door, door swicthes, colored red, green, blue, yellow, purple
 * 
 * Conveyor Belts, with swicthes to control direction, speed, on/off, diffent color?
 * 
 * Laser, long distance
 * 
 * Laser can refract through crystals and split, colored by gems, could be used in puzzles
 * 
 * Drill, short distance
 * 
 * show future objects surrounding current level for preview instead of empty areas
 * 
 * level editor, only objects currently availble in levels, as you get further more items are available.
 * 
 * Level exits availble in editor to levels you have completed
 * 
 * Last level exits to user created levels
 * 
 * could have ice levels with ice blocks and balls and floors
 * 
 * Multiple spawn points activate when touched, good for multiplayer
 * 
 * One way passage
 * 
 * Hole in the floor
 * 
 * Safe space
 * 
 * Could have monsters roll instead of walk/waddle
 * 
 * Back and forth/up and down movement monsters
 * 
 * random direction movement monsters, change when run into something
 * 
 * Each square should have a square object that is drawn under the m_object
 * 
 * Need access function to know what can go into the square for pipe and safe squares
 * 
 * Add a second lower level layer that things can fall down to, need elevator to get back up
 * 
 * Radioactivety change elements
 * 
 * Start rotating object out in random rotation position
 * 
 * Needs to take time to drill
 * 
 * Rotate monsters in place if stuck
 * 
 * amoebas need to spread based on time not percentage to process() function calls
 * 
 * Gravity switch changes direction (four ways) either walk over (enter or exit trigger) or bump into
 * 
 * One way path (boxes, and round objects go through only one way)
 * 
 * One way push boxes (can only be pushed certain directions)
 * 
 * switch toggle, switch requires object to be active, controls door
 * 
 * color code keys like in chips challenge
 * 
 * ice floors, cannot stop until reach wall
 * 
 * Multi player with multiple spawn points, co-op or competetive, need to store score with player not globally
 * 
 * can pickup explosive if haven't exploded yet
 * 
 * different powerfulness levels of explosives, + or X or box or big circle
 * 
 * spinning alert lights, yellow, white, red, blue, can be toggled on an off.
 * 
 * square and round door/floor plugs that come up from the ground with yellow hatch markings around the hole in the ground, toggles up and down
 * 
 * cage to capture things, or to be released, maybe with switch inside?
 * 
 * under ground pipes, like teleporter or actually present?
 * 
 * Squish player when run over by rock or monster
 * 
 * Sand, silt like minecraft and terria
 * 
 * portal based gun that allows you to teleport through the puzzle
 * 
 * Score like gears puzzle game, time to complete, distance travelled, gems collected, items collected, monsters killed, etc.
 * 
 * mirrors for lasers use thinkfun and khet as puzzle suggestions
 * 
 * Monsters become radio active when they hang around radioactive rock
 * 
 * Hidden areas defined in map, revielled when you enter them, hidden with planes
 * 
 * Border all areas with flat planes, need to match texture tiling with cube & board size
 * 
 * Entrace and exit with iris opening, light emitting light sunlight when open
 * 
 * could use oil to fuel player vehicle
 * 
 * use a model of a sack that is hidden in dirt that contains ore
 * 
 * crystal monsters, in different clear colors
 * 
 * share levels, rate them easy-hard, good-bad
 * 
 * how to handle liquids in pipes that are changed to solids boxes
 * 
 * gappling hook that can be shot and pull box/balls towards you
 * 
 * sand should stick to dirt and itself and not slide if next to it, sand boxes should always slide
 * 
 * sokoban, Boulderdash, chips challenge, crystal mines
 * procedurally generated sokoban http://larc.unt.edu/ian/research/sokoban/
 * 
 * xray tool to see hidden objects
 * 
 * sparkle hidden object
 * 
 * measure distance traveled for scoring purposes
 */

public enum DIRECTION {UP, DOWN, LEFT, RIGHT, NONE};

public abstract class OBJECT
{
	public OBJECT m_next_object;
	
	public SQUARE m_square;
	public SQUARE m_new_square;
	
	public bool m_round;
	
	public float m_verticle_velocity;
	public float m_horizontal_velocity;
	public float m_last_move_time;
	public float m_start_move_time;
	
	public float m_velocity_resolution;
	
	public GameObject m_game_object;
	
	public bool m_rolling;
	
	public abstract void Process();
	public abstract void Process_Move();	
	public abstract void Initialize();
	
	public enum OBJECT_COLOR {YELLOW, RED, GREEN, BLUE};
	
	public virtual void Destroy()
	{
		GameObject.Destroy(m_game_object);
	}
	
	public void Process_For_Round_Floating_Objects(float floatspeed, float rollspeed)
	{
		SQUARE square;
		
		square = m_square.m_above;
		
		// Balloons will rise to the square above if it is empty
		if (square.Occupied() == false)
		{
			square.m_board.Start_Move_Object(this, square, DIRECTION.UP, floatspeed, true);
		}
		else if (square.m_object.m_round == true)
		{
			square = m_square.m_right;
			
			// Balloons will float off of round objects above them if there is space on either side of the object below
			if ((square.Occupied() == false) 
				&& (square.m_above.Occupied() == false))
			{
				// fall off to the right
				m_square.m_board.Start_Move_Object(this, square, DIRECTION.RIGHT , rollspeed, true);
			}
			else 
			{
				square = m_square.m_left;
				
				if ((square.Occupied() == false) 
					&& (square.m_above.Occupied() == false))
				{
					// fall off to the left
					m_square.m_board.Start_Move_Object(this, square, DIRECTION.LEFT, rollspeed, true);
				}
				else if ((m_square.m_pipe_flow_down_direction != DIRECTION.NONE) &&
					(m_square.Get_Square_Forward(m_square.m_pipe_flow_up_direction).Occupied() == false))
				{
					// we are in a pipe, let's try going with the flow
					m_square.m_board.Start_Move_Object(this, m_square.Get_Square_Forward(m_square.m_pipe_flow_up_direction), m_square.m_pipe_flow_up_direction, m_square.m_pipe_flow_speed, true);
					if (m_moving_sound != null)
					{
						m_game_object.GetComponent<AudioSource>().loop = true;
						m_game_object.GetComponent<AudioSource>().clip = m_moving_sound; // TODO: make rolling sound in a pipe
						m_game_object.GetComponent<AudioSource>().Play();
					}
				}
				else if ((m_square.m_conveyor_belt == true) &&
					(m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction).Occupied() == false))
				{
					m_square.m_board.Start_Move_Object(this, m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction), m_square.m_conveyor_belt_direction, m_square.m_conveyor_belt_speed, false);
				}				
				else
				{
					// there are objects blocking the fall on both sides of the round object below so deactivate
					m_square.m_active = false;
					m_horizontal_velocity = 0;
					m_verticle_velocity = 0;
				}
			}
		}
		else if ((m_square.m_pipe_flow_down_direction != DIRECTION.NONE) &&
			(m_square.Get_Square_Forward(m_square.m_pipe_flow_up_direction).Occupied() == false))
		{
			// we are in a pipe, let's try going with the flow
			m_square.m_board.Start_Move_Object(this, m_square.Get_Square_Forward(m_square.m_pipe_flow_up_direction), m_square.m_pipe_flow_up_direction, rollspeed, true);
			if (m_moving_sound != null)
			{
				m_game_object.GetComponent<AudioSource>().loop = true;
				m_game_object.GetComponent<AudioSource>().clip = m_moving_sound; // TODO: make rolling sound in a pipe
				m_game_object.GetComponent<AudioSource>().Play();
			}
		}
		else if ((m_square.m_conveyor_belt == true) &&
			(m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction).Occupied() == false))
		{
			m_square.m_board.Start_Move_Object(this, m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction), m_square.m_conveyor_belt_direction, m_square.m_conveyor_belt_speed, false);
		}				
		else
		{
			// the object below is not round and so deactivate
			m_square.m_active = false;
			m_horizontal_velocity = 0;
			m_verticle_velocity = 0;
		}
	}
	
	public void Process_For_Square_Falling_Objects(float slide_speed)
	{
		SQUARE square;
		
		square = m_square.m_below;
		
		// square objects will slide to the square below if it is empty
		if (square.Occupied() == false)
		{
			square.m_board.Start_Move_Object(this, square, DIRECTION.DOWN, slide_speed, true);
			if (m_moving_sound != null)
			{
				m_game_object.GetComponent<AudioSource>().loop = true;
				m_game_object.GetComponent<AudioSource>().clip = m_moving_sound;
				m_game_object.GetComponent<AudioSource>().Play();
			}
		}
		// check for crush
		else if ((square.m_object.m_crushable == true) && (m_heavy == true) && (m_verticle_velocity != 0))
		{
			square.m_object.Crush();
		}
		else 
		{
			// check for hit
			if ((square.m_object.m_hitable == true) && (m_verticle_velocity != 0))
			{
				square.m_object.Hit();
			}
			
			// make sure it is not a pipe or occupied
			else if ((m_square.m_conveyor_belt == true) &&
				(m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction).Occupied() == false) &&
					(m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction).m_pipe == false))			
			{
				m_square.m_board.Start_Move_Object(this, m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction), m_square.m_conveyor_belt_direction, m_square.m_conveyor_belt_speed, false);
			}
			else
			{
				// deactivate
				m_square.m_active = false;
				m_horizontal_velocity = 0;
				m_verticle_velocity = 0;
				if (m_moving_sound != null)
				{
					m_game_object.GetComponent<AudioSource>().Stop();
				}
			}
		}
	}
	
	public void Process_For_Round_Falling_Objects(float fall_speed, float roll_speed)
	{
		SQUARE square;
		
		square = m_square.m_below;
		
		// round objects will fall to the square below if it is empty
		if (square.Occupied(DIRECTION.DOWN, fall_speed) == false)
		{
			square.m_board.Start_Move_Object(this, square, DIRECTION.DOWN, fall_speed, true);
			if (m_moving_sound != null)
			{
				m_game_object.GetComponent<AudioSource>().loop = true;
				m_game_object.GetComponent<AudioSource>().clip = m_moving_sound;
				m_game_object.GetComponent<AudioSource>().Play();
			}
		}
		// check for crush
		else if ((square.m_object.m_crushable == true) && (m_heavy == true) && (m_verticle_velocity != 0))
		{
			square.m_object.Crush();
		}
		else 
		{
			// check for hit
			if ((square.m_object.m_hitable == true) && (m_verticle_velocity != 0))
			{
				square.m_object.Hit();
			}
			
			//check for roll off
			if (square.m_object.m_round == true)
			{
				square = m_square.m_left;
				
				// round objects will fall off of round objects below them if there is space on either side of the object below
				if ((square.Occupied() == false) 
					&& (square.m_below.Occupied() == false))
				{
					// fall off to the left
					m_square.m_board.Start_Move_Object(this, square, DIRECTION.LEFT , roll_speed, true);
					if (m_moving_sound != null)
					{
						m_game_object.GetComponent<AudioSource>().loop = true;
						m_game_object.GetComponent<AudioSource>().clip = m_moving_sound;
						m_game_object.GetComponent<AudioSource>().Play();
					}
				}
				else 
				{
					square = m_square.m_right;
					
					if ((square.Occupied() == false) 
						&& (square.m_below.Occupied() == false))
					{
						// fall off to the right
						m_square.m_board.Start_Move_Object(this, square, DIRECTION.RIGHT, roll_speed, true);
						if (m_moving_sound != null)
						{
							m_game_object.GetComponent<AudioSource>().loop = true;
							m_game_object.GetComponent<AudioSource>().clip = m_moving_sound;
							m_game_object.GetComponent<AudioSource>().Play();
						}
					}
					else if ((m_square.m_pipe_flow_down_direction != DIRECTION.NONE) &&
						(m_square.Get_Square_Forward(m_square.m_pipe_flow_down_direction).Occupied() == false))
					{
						// we are in a pipe, let's try going with the flow
						m_square.m_board.Start_Move_Object(this, m_square.Get_Square_Forward(m_square.m_pipe_flow_down_direction), m_square.m_pipe_flow_down_direction, m_square.m_pipe_flow_speed, true);
						if (m_moving_sound != null)
						{
							m_game_object.GetComponent<AudioSource>().loop = true;
							m_game_object.GetComponent<AudioSource>().clip = m_moving_sound; // TODO: make rolling sound in a pipe
							m_game_object.GetComponent<AudioSource>().Play();
						}
					}
					else if ((m_square.m_conveyor_belt == true) &&
						(m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction).Occupied() == false))
					{
						m_square.m_board.Start_Move_Object(this, m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction), m_square.m_conveyor_belt_direction, m_square.m_conveyor_belt_speed, false);
					}
					else
					{
						// there are objects blocking the fall on both sides of the round object below so deactivate
						m_square.m_active = false;
						m_horizontal_velocity = 0;				
						m_verticle_velocity = 0;
						if (m_moving_sound != null)
						{
						 	m_game_object.GetComponent<AudioSource>().Stop();
						}
					}
				}
			}
			else if ((m_square.m_pipe_flow_down_direction != DIRECTION.NONE) &&
				(m_square.Get_Square_Forward(m_square.m_pipe_flow_down_direction).Occupied() == false))
			{
				// we are in a pipe, let's try going with the flow
				m_square.m_board.Start_Move_Object(this, m_square.Get_Square_Forward(m_square.m_pipe_flow_down_direction), m_square.m_pipe_flow_down_direction, m_square.m_pipe_flow_speed, true);
				if (m_moving_sound != null)
				{
					m_game_object.GetComponent<AudioSource>().loop = true;
					m_game_object.GetComponent<AudioSource>().clip = m_moving_sound; // TODO: make rolling sound in a pipe
					m_game_object.GetComponent<AudioSource>().Play();
				}
			}
			else if ((m_square.m_conveyor_belt == true) &&
				(m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction).Occupied() == false))			
			{
				m_square.m_board.Start_Move_Object(this, m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction), m_square.m_conveyor_belt_direction, m_square.m_conveyor_belt_speed, false);
			}
			else
			{
				// the object below is not round and so deactivate
				m_square.m_active = false;
				m_horizontal_velocity = 0;
				m_verticle_velocity = 0;
				if (m_moving_sound != null)
				{
					m_game_object.GetComponent<AudioSource>().Stop();
				}
			}
		}
	}
	
    public void Process_Move_For_Round_Floating_Objects()
	{
		float time_difference;
		
		if (((Mathf.Abs(m_horizontal_velocity + m_verticle_velocity) 
			* (Time.time - m_start_move_time)) / m_velocity_resolution) >= 1.0)
		{
			m_square.m_board.Move_Object(this, m_new_square);
			m_new_square = null;
		}
		else
		{
			time_difference = (Time.time - m_last_move_time) 
				* m_square.m_board.m_square_size;
			
//			Set_Position(
//				m_square.m_board.m_square_size * (m_square.m_column - (m_square.m_board.m_width /2)) + (m_horizontal_velocity * (Time.time - m_start_move_time)) / m_velocity_resolution,
//				m_square.m_board.m_square_size * (-m_square.m_row + (m_square.m_board.m_height / 2)) + (m_verticle_velocity * (Time.time - m_start_move_time)) / m_velocity_resolution, 
//				m_square.m_board.m_depth);
			
//			Offset_Position(
//				(m_horizontal_velocity * time_difference) / m_velocity_resolution,
//				(m_verticle_velocity * time_difference) / m_velocity_resolution, 
//				0);
			
			Vector3 target_position;
			Vector3 start_position;
			
			start_position.x = m_square.m_board.m_square_size * (m_square.m_column - (m_square.m_board.m_width /2));
			start_position.y = m_square.m_board.m_square_size * (-m_square.m_row + (m_square.m_board.m_height / 2));
			start_position.z = m_square.m_board.m_depth;
			
			target_position.x = m_new_square.m_board.m_square_size * (m_new_square.m_column - (m_new_square.m_board.m_width /2));
			target_position.y = m_new_square.m_board.m_square_size * (-m_new_square.m_row + (m_new_square.m_board.m_height / 2));
			target_position.z = m_new_square.m_board.m_depth;
			
			if (m_horizontal_velocity != 0)
				target_position.x = m_square.m_board.m_square_size * (m_square.m_column - (m_square.m_board.m_width /2) + (m_horizontal_velocity / Mathf.Abs(m_horizontal_velocity))) ;
			else
				target_position.x = start_position.x;
			if (m_verticle_velocity != 0)
				target_position.y = m_square.m_board.m_square_size * (-m_square.m_row + (m_square.m_board.m_height / 2) + (m_verticle_velocity / Mathf.Abs(m_verticle_velocity))) ;
			else
				target_position.y = start_position.y;
			target_position.z = m_square.m_board.m_depth;			
			
			Offset_Position(start_position, target_position, 
				((Mathf.Abs(m_verticle_velocity + m_horizontal_velocity) * (Time.time - m_start_move_time)) / m_velocity_resolution));

			if ((m_rolling == true) &&
					((m_horizontal_velocity != 0) || (m_verticle_velocity != 0)))
			{
				float circ = m_square.m_board.m_square_size * Mathf.PI;
				
				if (m_verticle_velocity != 0)
				{
 					// floating objects should only rotate when rolling off of things or being push side to side not when rising up
					//Rotate_X((m_verticle_velocity * time_difference / m_velocity_resolution) / circ * 360);
					// rotate slowly while floating up
					Rotate_Y((m_verticle_velocity * 0.5f * time_difference / m_velocity_resolution) / circ * 360);
				} 
				else if (m_horizontal_velocity != 0)
				{
					Rotate_Z((m_horizontal_velocity * time_difference / m_velocity_resolution) / circ * 360);
				}
			}
		}
	}
	
	public void Process_Move_For_Round_Falling_Objects()
	{
		float time_difference;
		
		if (((Mathf.Abs(m_horizontal_velocity + m_verticle_velocity) 
			* (Time.time - m_start_move_time)) / m_velocity_resolution) >= 1.0)
		{
			if ((m_new_square.m_below.Occupied() == true) && (m_new_square.m_below.m_object.m_crushable == true) && (m_heavy == true) && (m_verticle_velocity != 0))
			{
				m_new_square.m_below.m_object.Crush();
			}
			
			if ((m_new_square.m_below.Occupied() == true) && (m_new_square.m_below.m_object.m_hitable == true) && (m_verticle_velocity != 0))
			{
				m_new_square.m_below.m_object.Hit();
			}
			
			m_square.m_board.Move_Object(this, m_new_square);
			m_new_square = null;
		}
		else
		{
			time_difference = (Time.time - m_last_move_time) 
				* m_square.m_board.m_square_size;
			
//			Set_Position(
//				m_square.m_board.m_square_size * (m_square.m_column - (m_square.m_board.m_width /2)) + (m_horizontal_velocity * (Time.time - m_start_move_time)) / m_velocity_resolution,
//				m_square.m_board.m_square_size * (-m_square.m_row + (m_square.m_board.m_height / 2)) + (m_verticle_velocity * (Time.time - m_start_move_time)) / m_velocity_resolution, 
//				m_square.m_board.m_depth);
			
//			Offset_Position(
//				(m_horizontal_velocity * time_difference) / m_velocity_resolution,
//				(m_verticle_velocity * time_difference) / m_velocity_resolution, 
//				0);
			
			Vector3 target_position;
			Vector3 start_position;
			
			start_position.x = m_square.m_board.m_square_size * (m_square.m_column - (m_square.m_board.m_width /2));
			start_position.y = m_square.m_board.m_square_size * (-m_square.m_row + (m_square.m_board.m_height / 2));
			start_position.z = m_square.m_board.m_depth;
			
//			target_position.x = m_new_square.m_board.m_square_size * (m_new_square.m_column - (m_new_square.m_board.m_width /2));
//			target_position.y = m_new_square.m_board.m_square_size * (-m_new_square.m_row + (m_new_square.m_board.m_height / 2));
//			target_position.z = m_new_square.m_board.m_depth;
			
			if (m_horizontal_velocity != 0)
				target_position.x = m_square.m_board.m_square_size * (m_square.m_column - (m_square.m_board.m_width /2) + (m_horizontal_velocity / Mathf.Abs(m_horizontal_velocity))) ;
			else
				target_position.x = start_position.x;
			if (m_verticle_velocity != 0)
				target_position.y = m_square.m_board.m_square_size * (-m_square.m_row + (m_square.m_board.m_height / 2) + (m_verticle_velocity / Mathf.Abs(m_verticle_velocity))) ;
			else
				target_position.y = start_position.y;
			target_position.z = m_square.m_board.m_depth;			
			
			Offset_Position(start_position, target_position, 
				((Mathf.Abs(m_verticle_velocity + m_horizontal_velocity) * (Time.time - m_start_move_time)) / m_velocity_resolution));

			if ((m_rolling == true) && 
					((m_horizontal_velocity != 0) || (m_verticle_velocity != 0)))
			{
				float circ = m_square.m_board.m_square_size * Mathf.PI;
				
				if (m_verticle_velocity != 0)
				{
					Rotate_X((m_verticle_velocity * time_difference / m_velocity_resolution) / circ * 360);
				} 
				else if (m_horizontal_velocity != 0)
				{
					Rotate_Z((-m_horizontal_velocity * time_difference / m_velocity_resolution) / circ * 360);
				}
			}
		}
	}
	
	public void Process_Move_For_Square_Falling_Objects()
	{
//		float time_difference;
		
		if (((Mathf.Abs(m_horizontal_velocity + m_verticle_velocity) 
			* (Time.time - m_start_move_time)) / m_velocity_resolution) >= 1.0)
		{
			if ((m_new_square.m_below.Occupied() == true) && (m_new_square.m_below.m_object.m_crushable == true) && (m_heavy == true) && (m_verticle_velocity != 0))
			{
				m_new_square.m_below.m_object.Crush();
			}
			
			m_square.m_board.Move_Object(this, m_new_square);
			m_new_square = null;
		}
		else
		{
//			time_difference = (Time.time - m_last_move_time) 
//				* m_square.m_board.m_square_size;
			
//			Set_Position(
//				m_square.m_board.m_square_size * (m_square.m_column - (m_square.m_board.m_width /2)) + (m_horizontal_velocity * (Time.time - m_start_move_time)) / m_velocity_resolution,
//				m_square.m_board.m_square_size * (-m_square.m_row + (m_square.m_board.m_height / 2)) + (m_verticle_velocity * (Time.time - m_start_move_time)) / m_velocity_resolution, 
//				m_square.m_board.m_depth);
			
//			Offset_Position(
//				(m_horizontal_velocity * time_difference) / m_velocity_resolution,
//				(m_verticle_velocity * time_difference) / m_velocity_resolution, 
//				0);
			
			Vector3 target_position;
			Vector3 start_position;
			
			start_position.x = m_square.m_board.m_square_size * (m_square.m_column - (m_square.m_board.m_width /2));
			start_position.y = m_square.m_board.m_square_size * (-m_square.m_row + (m_square.m_board.m_height / 2));
			start_position.z = m_square.m_board.m_depth;
			
//			target_position.x = m_new_square.m_board.m_square_size * (m_new_square.m_column - (m_new_square.m_board.m_width /2));
//			target_position.y = m_new_square.m_board.m_square_size * (-m_new_square.m_row + (m_new_square.m_board.m_height / 2));
//			target_position.z = m_new_square.m_board.m_depth;
			
			if (m_horizontal_velocity != 0)
				target_position.x = m_square.m_board.m_square_size * (m_square.m_column - (m_square.m_board.m_width /2) + (m_horizontal_velocity / Mathf.Abs(m_horizontal_velocity))) ;
			else
				target_position.x = start_position.x;
			if (m_verticle_velocity != 0)
				target_position.y = m_square.m_board.m_square_size * (-m_square.m_row + (m_square.m_board.m_height / 2) + (m_verticle_velocity / Mathf.Abs(m_verticle_velocity))) ;
			else
				target_position.y = start_position.y;
			target_position.z = m_square.m_board.m_depth;			
			
			Offset_Position(start_position, target_position, 
				((Mathf.Abs(m_verticle_velocity + m_horizontal_velocity) * (Time.time - m_start_move_time)) / m_velocity_resolution));
		}
	}
	
	public void Process_Move_For_Round_Stationary_Objects()
	{
		
		if (((Mathf.Abs(m_horizontal_velocity + m_verticle_velocity) 
			* (Time.time - m_start_move_time)) / m_velocity_resolution) >= 1.0)
		{
			m_square.m_board.Move_Object(this, m_new_square);
			m_new_square = null;
		}
		else
		{
			float time_difference;
			float circ;
			
			circ = m_square.m_board.m_square_size * Mathf.PI;
			
			time_difference = (Time.time - m_last_move_time) 
					* m_square.m_board.m_square_size;
			
//			Set_Position(
//				m_square.m_board.m_square_size * (m_square.m_column - (m_square.m_board.m_width /2)) + (m_horizontal_velocity * (Time.time - m_start_move_time)) / m_velocity_resolution,
//				m_square.m_board.m_square_size * (-m_square.m_row + (m_square.m_board.m_height / 2)) + (m_verticle_velocity * (Time.time - m_start_move_time)) / m_velocity_resolution, 
//				m_square.m_board.m_depth);
			
//			Offset_Position(
//				(m_horizontal_velocity * time_difference) / m_velocity_resolution,
//				(m_verticle_velocity * time_difference) / m_velocity_resolution, 
//				0);

			Vector3 target_position;
			Vector3 start_position;
			
			start_position.x = m_square.m_board.m_square_size * (m_square.m_column - (m_square.m_board.m_width /2));
			start_position.y = m_square.m_board.m_square_size * (-m_square.m_row + (m_square.m_board.m_height / 2));
			start_position.z = m_square.m_board.m_depth;

			if (m_new_square != null)
			{
//				target_position.x = m_new_square.m_board.m_square_size * (m_new_square.m_column - (m_new_square.m_board.m_width /2));
//				target_position.y = m_new_square.m_board.m_square_size * (-m_new_square.m_row + (m_new_square.m_board.m_height / 2));
//				target_position.z = m_new_square.m_board.m_depth;
				
				if (m_horizontal_velocity != 0)
					target_position.x = m_square.m_board.m_square_size * (m_square.m_column - (m_square.m_board.m_width /2) + (m_horizontal_velocity / Mathf.Abs(m_horizontal_velocity))) ;
				else
					target_position.x = start_position.x;
				if (m_verticle_velocity != 0)
					target_position.y = m_square.m_board.m_square_size * (-m_square.m_row + (m_square.m_board.m_height / 2) + (m_verticle_velocity / Mathf.Abs(m_verticle_velocity))) ;
				else
					target_position.y = start_position.y;
				target_position.z = m_square.m_board.m_depth;			
			}
			else
			{
				target_position = start_position;
			}		

			Offset_Position(start_position, target_position, 
				((Mathf.Abs(m_verticle_velocity + m_horizontal_velocity) * (Time.time - m_start_move_time)) / m_velocity_resolution));

			if (m_rolling == true)
			{
				if ((m_horizontal_velocity != 0) || (m_verticle_velocity != 0))
				{
					if (m_verticle_velocity != 0)
					{
						Rotate_X((m_verticle_velocity * time_difference / m_velocity_resolution) / circ * 360);
					} 
					else if (m_horizontal_velocity != 0)
					{
						Rotate_Y((m_horizontal_velocity * time_difference / m_velocity_resolution) / circ * 360);
					}
				}
				else
				{
					// this have to be delta time because we don't have a valid time_difference right now because we are not moving
					Rotate_Z((15.0f * Time.deltaTime / m_velocity_resolution) / circ * 360);
				}
			}
		}
	}
	
	public void Process_Move_For_Stationary_Objects()
	{
//		float time_difference;
		
		if (((Mathf.Abs(m_verticle_velocity + m_horizontal_velocity) 
			* (Time.time - m_start_move_time)) / m_velocity_resolution) >= 1.0)
		{
			m_square.m_board.Move_Object(this, m_new_square);
			m_new_square = null;
		}
		else
		{
//			time_difference = (Time.time - m_last_move_time) 
//				* m_square.m_board.m_square_size;
			
			Vector3 target_position;
			Vector3 start_position;
			
			start_position.x = m_square.m_board.m_square_size * (m_square.m_column - (m_square.m_board.m_width /2));
			start_position.y = m_square.m_board.m_square_size * (-m_square.m_row + (m_square.m_board.m_height / 2));
			start_position.z = m_square.m_board.m_depth;
			
//			target_position.x = m_new_square.m_board.m_square_size * (m_new_square.m_column - (m_new_square.m_board.m_width /2));
//			target_position.y = m_new_square.m_board.m_square_size * (-m_new_square.m_row + (m_new_square.m_board.m_height / 2));
//			target_position.z = m_new_square.m_board.m_depth;
			
			if (m_horizontal_velocity != 0)
				target_position.x = m_square.m_board.m_square_size * (m_square.m_column - (m_square.m_board.m_width /2) + (m_horizontal_velocity / Mathf.Abs(m_horizontal_velocity))) ;
			else
				target_position.x = start_position.x;
			if (m_verticle_velocity != 0)
				target_position.y = m_square.m_board.m_square_size * (-m_square.m_row + (m_square.m_board.m_height / 2) + (m_verticle_velocity / Mathf.Abs(m_verticle_velocity))) ;
			else
				target_position.y = start_position.y;
			target_position.z = m_square.m_board.m_depth;			
			
			Offset_Position(start_position, target_position, 
				((Mathf.Abs(m_verticle_velocity + m_horizontal_velocity) * (Time.time - m_start_move_time)) / m_velocity_resolution));

//			Set_Position(
//				m_square.m_board.m_square_size * (m_square.m_column - (m_square.m_board.m_width /2)) + (m_horizontal_velocity * (Time.time - m_start_move_time)) / m_velocity_resolution,
//				m_square.m_board.m_square_size * (-m_square.m_row + (m_square.m_board.m_height / 2)) + (m_verticle_velocity * (Time.time - m_start_move_time)) / m_velocity_resolution, 
//				m_square.m_board.m_depth);
			
			//Offset_Position(
			//	(m_horizontal_velocity * time_difference) / m_velocity_resolution,
			//	(m_verticle_velocity * time_difference) / m_velocity_resolution, 
			//	0);
		}
	}

	// action bools
	public bool m_pushable;
	public bool m_crushable;
	public bool m_drillable;
	public bool m_eatable;
	public bool m_pickupable;
	public bool m_explodeable;
	public bool m_heavy;
	public bool m_hitable;
	public bool m_openable;
	public AudioClip m_moving_sound;
	
	public virtual void SetSquare(SQUARE square)
	{
		m_square = square;
	}
	
	// default action functions	
	public virtual bool Crush()
	{
		return false;
	}
	
	public virtual bool Eat(OBJECT eater)
	{
		return false;
	}

	public virtual bool Explode()
	{
		return false;
	}

	public virtual bool Drill()
	{
		return false;
	}
	
	public virtual bool Pickup(OBJECT pickuper)
	{
		return false;
	}
	
	public virtual bool Hit()
	{
		return false;
	}
	
	public virtual bool Toggle(OBJECT_COLOR color)
	{
		return false;
	}
	
	public virtual bool Open()
	{
		return false;
	}
	
	public virtual bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		// check if not already moving
		if (m_square.m_object.m_new_square == null)
		{
			SQUARE direction_square;
			
			direction_square = m_square.Get_Square_Forward(direction);
			// first check if there is room to move
			if ((direction_square.Occupied() == false) &&
				// if it is round then allow push
				((m_round == true) ||
				// if the object is not round make sure it is not a pipe
				((m_round == false) && (direction_square.m_pipe == false))))
			{
				m_square.m_board.Start_Move_Object(this, direction_square, direction, push_object_speed, rolling);
				return true;
			}
		}
		
		return false;
	}

	public void Initialize_Object()
	{
		m_next_object = null;
		
		m_square =  null;
		m_new_square =  null;
	
		m_round = false;
		
		m_openable = false;
		m_pushable = false;
		m_crushable = false;
		m_eatable = false;
		m_drillable = false;
		m_pickupable = false;
		m_explodeable = false;
		m_heavy = false;
		m_hitable = false;
		m_moving_sound = null;
		
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
		m_last_move_time = 0;
		m_start_move_time = 0;
		
		m_velocity_resolution = 2.0f;
		
		m_game_object = null;
		
		m_rolling = false;
	}
	
	public void Offset_Position(float x, float y, float z)
	{
		m_game_object.transform.Translate(x, y, z, Space.World);
	}
	
	public virtual void Offset_Position(Vector3 start_position, Vector3 target_position, float transition)
	{
		m_game_object.transform.position = Vector3.Lerp(start_position, target_position, transition);
	}

	public virtual void Set_Position(float x, float y, float z)
	{
		m_game_object.transform.Translate(x - m_game_object.transform.position.x, 
				y - m_game_object.transform.position.y, 
				z - m_game_object.transform.position.z, Space.World);
	}
	
	public void Rotate_X(float rad)
	{
		m_game_object.transform.Rotate (Vector3.right, rad, Space.World);
	}
	
	public void Rotate_Y(float rad)
	{
		m_game_object.transform.Rotate (Vector3.down, rad, Space.World);
	}
	
	public void Rotate_Z(float rad)
	{
		m_game_object.transform.Rotate (Vector3.forward, rad, Space.World);
	}
};

public class STONE_BALL: OBJECT
{
	float m_fall_speed;
	float m_roll_speed;
	AudioClip m_hit_sound;

	public override void Initialize()
	{
		Initialize_Object();
		
		// balls are round and pushable and heavy
		m_round = true;
		m_pushable = true;
		m_heavy = true;
		m_hitable = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Stone Ball"), Vector3.zero, Quaternion.identity) as GameObject;
		
		m_hit_sound = MINE_AUDIO.Instance.m_hit_sound;
		m_moving_sound = MINE_AUDIO.Instance.m_moving_sound;

		m_fall_speed = 3.0f;
		m_roll_speed = 2.0f;
		
		// start out in a random orientation so they are not all alike on the board
		Rotate_X(Random.Range(0,360));
		Rotate_Y(Random.Range(0,360));
		Rotate_Z(Random.Range(0,360));
	}
	
	public override bool Hit()
	{
		//this.m_game_object.audio.PlayOneShot(m_hit_sound);
		
		return true;
	}
	
	public override void Process()
	{
		Process_For_Round_Falling_Objects(m_fall_speed, m_roll_speed);
	}
	
	public override void Process_Move()
	{
		Process_Move_For_Round_Falling_Objects();
	}
}

public class ROCK_BALL: OBJECT
{
	float m_fall_speed;
	float m_roll_speed;
	AudioClip m_hit_sound;

	public override bool Explode()
	{
		m_square.m_board.Remove_Object(this);
		
		m_square.Activate_All_Around_Square();
		
		return true;
	}
	
	public override void Initialize()
	{
		Initialize_Object();
		
		// balls are round and pushable and heavy
		m_round = true;
		m_pushable = true;
		m_heavy = true;
		m_hitable = true;
		m_explodeable = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Rock Ball"), Vector3.zero, Quaternion.identity) as GameObject;
		
		m_hit_sound = MINE_AUDIO.Instance.m_hit_sound;
		m_moving_sound = MINE_AUDIO.Instance.m_moving_sound;

		m_fall_speed = 3.0f;
		m_roll_speed = 2.0f;
		
		// start out in a random orientation so they are not all alike on the board
		Rotate_X(Random.Range(0,360));
		Rotate_Y(Random.Range(0,360));
		Rotate_Z(Random.Range(0,360));
	}
	
	public override bool Hit()
	{
		//this.m_game_object.audio.PlayOneShot(m_hit_sound);

		return true;
	}
	
	public override void Process()
	{
		Process_For_Round_Falling_Objects(m_fall_speed, m_roll_speed);
	}
	
	public override void Process_Move()
	{
		Process_Move_For_Round_Falling_Objects();
	}
}

public class ROCK_MONSTER_HIDDEN: OBJECT
{
	float m_fall_speed;
	float m_roll_speed;
	//AudioClip m_hit_sound;

	public override bool Drill()
	{
		ROCK_MONSTER monster;
		monster = new ROCK_MONSTER();
		monster.Initialize();
		m_square.m_board.Place_Object(monster, m_square);
		
		m_square.Activate_All_Around_Square();
		
		return true;
	}
	
	public override bool Hit()
	{
		ROCK_MONSTER monster;
		monster = new ROCK_MONSTER();
		monster.Initialize();
		m_square.m_board.Place_Object(monster, m_square);
		
		m_square.Activate_All_Around_Square();
		
		return true;
	}
	
	public override bool Crush()
	{
		ROCK_MONSTER monster;
		monster = new ROCK_MONSTER();
		monster.Initialize();
		m_square.m_board.Place_Object(monster, m_square);
		
		m_square.Activate_All_Around_Square();
		
		return true;
	}
	
	public override bool Explode()
	{
		ROCK_MONSTER monster;
		monster = new ROCK_MONSTER();
		monster.Initialize();
		m_square.m_board.Place_Object(monster, m_square);
		
		m_square.Activate_All_Around_Square();
			
		return true;
	}

	public override void Initialize()
	{
		Initialize_Object();
		
		// balls are round and pushable and heavy
		m_round = true;
		m_pushable = true;
		m_heavy = true;
		m_hitable = true;
		m_crushable = true;
		m_explodeable = true;
		m_drillable = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Rock Ball"), Vector3.zero, Quaternion.identity) as GameObject;
		
		//m_hit_sound = GameObject.Instantiate((AudioClip)Resources.Load("Hit")) as AudioClip;
		//m_moving_sound = GameObject.Instantiate((AudioClip)Resources.Load("Rolling")) as AudioClip;

		m_fall_speed = 3.0f;
		m_roll_speed = 2.0f;
		
		// start out in a random orientation so they are not all alike on the board
		Rotate_X(Random.Range(0,360));
		Rotate_Y(Random.Range(0,360));
		Rotate_Z(Random.Range(0,360));
	}
	
	public override void Process()
	{
		Process_For_Round_Falling_Objects(m_fall_speed, m_roll_speed);
	}
	
	public override void Process_Move()
	{
		Process_Move_For_Round_Falling_Objects();
	}
}
public class LAVA_STONE_BALL: OBJECT
{
	float m_fall_speed;
	float m_roll_speed;
	AudioClip m_hit_sound;

	public override void Initialize()
	{
		Initialize_Object();
		
		// balls are round and pushable and heavy
		m_round = true;
		m_pushable = true;
		m_heavy = true;
		m_hitable = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Lava Stone Ball"), Vector3.zero, Quaternion.identity) as GameObject;
		
		m_hit_sound = MINE_AUDIO.Instance.m_hit_sound; //GameObject.Instantiate((AudioClip)Resources.Load("Hit")) as AudioClip;
		//m_moving_sound = GameObject.Instantiate((AudioClip)Resources.Load("Rolling")) as AudioClip;

		m_fall_speed = 3.0f;
		m_roll_speed = 2.0f;
		
		// start out in a random orientation so they are not all alike on the board
		Rotate_X(Random.Range(0,360));
		Rotate_Y(Random.Range(0,360));
		Rotate_Z(Random.Range(0,360));
	}
	
	public override bool Hit()
	{
		this.m_game_object.GetComponent<AudioSource>().PlayOneShot(m_hit_sound);
		
		return true;
	}
	
	public override void Process()
	{
		Process_For_Round_Falling_Objects(m_fall_speed, m_roll_speed);
	}
	
	public override void Process_Move()
	{
		Process_Move_For_Round_Falling_Objects();
	}
}

public class SOFT_ROCK_BALL: OBJECT
{
	float m_fall_speed;
	float m_roll_speed;
	AudioClip m_hit_sound;

	public override bool Drill()
	{
		m_square.m_board.Remove_Object(this);
		
		m_square.Activate_All_Around_Square();
		
		return true;
	}
	
	public override bool Explode()
	{
		m_square.m_board.Remove_Object(this);
		
		m_square.Activate_All_Around_Square();
		
		return true;
	}
	
	public override void Initialize()
	{
		Initialize_Object();
		
		// balls are round and pushable and heavy
		m_round = true;
		m_pushable = true;
		m_heavy = true;
		m_hitable = true;
		m_explodeable = true;
		m_drillable = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Soft Rock Ball"), Vector3.zero, Quaternion.identity) as GameObject;
		
		m_hit_sound = MINE_AUDIO.Instance.m_hit_sound; //GameObject.Instantiate((AudioClip)Resources.Load("Hit")) as AudioClip;
		m_moving_sound = MINE_AUDIO.Instance.m_moving_sound;

		m_fall_speed = 3.0f;
		m_roll_speed = 2.0f;
		
		// start out in a random orientation so they are not all alike on the board
		Rotate_X(Random.Range(0,360));
		Rotate_Y(Random.Range(0,360));
		Rotate_Z(Random.Range(0,360));
	}
	
	public override bool Hit()
	{
		this.m_game_object.GetComponent<AudioSource>().PlayOneShot(m_hit_sound);
		
		return true;
	}
	
	public override void Process()
	{
		Process_For_Round_Falling_Objects(m_fall_speed, m_roll_speed);
	}
	
	public override void Process_Move()
	{
		Process_Move_For_Round_Falling_Objects();
	}
}

public class SAND: OBJECT
{
	float m_slide_speed;
	//AudioClip m_slide_sound;

	public override bool Drill()
	{
		m_square.m_board.Remove_Object(this);
		
		m_square.Activate_All_Around_Square();
		
		return true;
	}
	
	public override bool Explode()
	{
		m_square.m_board.Remove_Object(this);
		
		m_square.Activate_All_Around_Square();
		
		return true;
	}
	
	public override void Initialize()
	{
		Initialize_Object();
		
		m_pushable = true;
		m_heavy = true;
		m_hitable = true;
		m_explodeable = true;
		m_drillable = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Sand"), Vector3.zero, Quaternion.identity) as GameObject;
		
		//m_slide_sound = GameObject.Instantiate((AudioClip)Resources.Load("Slide")) as AudioClip;

		m_slide_speed = 2.0f;
	}
	
	public override bool Hit()
	{
		//this.m_game_object.audio.PlayOneShot(m_hit_sound);
		
		return true;
	}
	
	public override void Process()
	{
		Process_For_Square_Falling_Objects(m_slide_speed);
	}
	
	public override void Process_Move()
	{
		Process_Move_For_Square_Falling_Objects();
	}
}

public class SAND_BOX: OBJECT
{
	float m_slide_speed;
	//AudioClip m_slide_sound;

	public override bool Drill()
	{
		m_square.m_board.Remove_Object(this);
		
		m_square.Activate_All_Around_Square();
		
		return true;
	}
	
	public override bool Explode()
	{
		m_square.m_board.Remove_Object(this);
		
		m_square.Activate_All_Around_Square();
		
		return true;
	}
	
	public override void Initialize()
	{
		Initialize_Object();
		
		m_pushable = true;
		m_heavy = true;
		m_hitable = true;
		m_explodeable = true;
		m_drillable = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Sand Box"), Vector3.zero, Quaternion.identity) as GameObject;
		
		//m_slide_sound = GameObject.Instantiate((AudioClip)Resources.Load("Slide")) as AudioClip;

		m_slide_speed = 2.0f;
	}
	
	public override bool Hit()
	{
		//this.m_game_object.audio.PlayOneShot(m_hit_sound);
		
		return true;
	}
	
	public override void Process()
	{
		Process_For_Square_Falling_Objects(m_slide_speed);
	}
	
	public override void Process_Move()
	{
		Process_Move_For_Square_Falling_Objects();
	}
}

public class BALLOON: OBJECT
{
	float m_speed;
	
	public override bool Drill()
	{
		m_square.m_board.Remove_Object(this);
		
		m_square.Activate_All_Around_Square();
		
		return true;
	}

	public override bool Explode()
	{
		AMOEBA amoeba;
		amoeba = new AMOEBA();
		amoeba.Initialize();
		m_square.m_board.Place_Object(amoeba, m_square);
		
		m_square.Activate_All_Around_Square();
		
		return true;
	}

	public override void Initialize()
	{
		Initialize_Object();

		// Balloons are round and moveable
		m_round = true;
		m_pushable = true;
		m_explodeable = true;
		m_drillable = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Balloon"), Vector3.zero, Quaternion.identity) as GameObject;
		
		m_speed = 1.0f;
	}
	
	override public void Process()
	{
		Process_For_Round_Floating_Objects(m_speed, m_speed);
	}
	
	override public void Process_Move()
	{
		Process_Move_For_Round_Floating_Objects();
	}
};

public class STONE_BOX: OBJECT
{
	public override void Initialize()
	{
		Initialize_Object();

		m_pushable = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Stone Box"), Vector3.zero, Quaternion.identity) as GameObject;
	}
	
	public override void Process()
	{
		if ((m_square.m_conveyor_belt == true) &&
			(m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction).Occupied() == false) &&
			(m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction).m_pipe == false))
		{
			m_square.m_board.Start_Move_Object(this, m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction), m_square.m_conveyor_belt_direction, m_square.m_conveyor_belt_speed, false);
			m_square.m_active = true;
		}
		else
		{
			// boxes do not need to be processed because they don't 
			// do anything by themselves so deactivate
			m_square.m_active = false;
			m_horizontal_velocity = 0;
			m_verticle_velocity = 0;
		}
	}
	
	public override void Process_Move()
	{
		Process_Move_For_Stationary_Objects();
	}
};

public class ROCK_BOX: OBJECT
{
	public override bool Explode()
	{
		// we need to make sure the box is not moving before we change it to a ball as we could end up with both a box and a ball and remove the player if we are not careful
		if (m_new_square == null)
		{
			ROCK_BALL ball;
			ball = new ROCK_BALL();
			ball.Initialize();
			m_square.m_board.Place_Object(ball, m_square);
			
			m_square.Activate_All_Around_Square();
			
			return true;
		}
		else
		{
			return false;
		}
	}

	public override void Initialize()
	{
		Initialize_Object();
		
		m_pushable = true;
		m_explodeable = true;
		m_game_object = GameObject.Instantiate(Resources.Load("Rock Box"), Vector3.zero, Quaternion.identity) as GameObject;
	}
	
	public override void Process()
	{
		if ((m_square.m_conveyor_belt == true) &&
			(m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction).Occupied() == false) &&
			(m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction).m_pipe == false))
		{
			m_square.m_board.Start_Move_Object(this, m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction), m_square.m_conveyor_belt_direction, m_square.m_conveyor_belt_speed, false);
			m_square.m_active = true;
		}
		else
		{
			// boxes do not need to be processed because they don't 
			// do anything by themselves so deactivate
			m_square.m_active = false;
			m_horizontal_velocity = 0;
			m_verticle_velocity = 0;
		}
	}
	
	public override void Process_Move()
	{
		Process_Move_For_Stationary_Objects();
	}
};

public class SOFT_ROCK_BOX: OBJECT
{
	public override bool Drill()
	{
		// we need to make sure the box is not moving before we change it to a ball as we could end up with both a box and a ball and remove the player if we are not careful
		if (m_new_square == null)
		{
			SOFT_ROCK_BALL ball;
			ball = new SOFT_ROCK_BALL();
			ball.Initialize();
			m_square.m_board.Place_Object(ball, m_square);
			
			m_square.Activate_All_Around_Square();
			
			return true;
		}
		else
		{
			return false;
		}
	}

	public override bool Explode()
	{
		// we need to make sure the box is not moving before we change it to a ball as we could end up with both a box and a ball and remove the player if we are not careful
		if (m_new_square == null)
		{
			SOFT_ROCK_BALL ball;
			ball = new SOFT_ROCK_BALL();
			ball.Initialize();
			m_square.m_board.Place_Object(ball, m_square);
			
			m_square.Activate_All_Around_Square();
			
			return true;
		}
		else
		{
			return false;
		}
	}

	public override void Initialize()
	{
		Initialize_Object();

		m_pushable = true;
		m_drillable = true;
		m_explodeable = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Soft Rock Box"), Vector3.zero, Quaternion.identity) as GameObject;
	}
	
	public override void Process()
	{
		if ((m_square.m_conveyor_belt == true) &&
			(m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction).Occupied() == false) &&
			(m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction).m_pipe == false))
		{
			m_square.m_board.Start_Move_Object(this, m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction), m_square.m_conveyor_belt_direction, m_square.m_conveyor_belt_speed, false);
			m_square.m_active = true;
		}
		else
		{
			// boxes do not need to be processed because they don't 
			// do anything by themselves so deactivate
			m_square.m_active = false;
			m_horizontal_velocity = 0;
			m_verticle_velocity = 0;
		}
	}
	
	public override void Process_Move()
	{
		Process_Move_For_Stationary_Objects();
	}
};

public class PIPE_VERTICAL: OBJECT
{
	SQUARE m_pipe_square;
	
	public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}
	
	public override void Initialize()
	{
		Initialize_Object();
		
		m_game_object = GameObject.Instantiate(Resources.Load("Pipe"), Vector3.zero, Quaternion.identity) as GameObject;
	}
	
	public override void SetSquare(SQUARE square)
	{
		// assigned my square
		m_square = square;
		
		// create a new square to carry piped items
		m_pipe_square = new SQUARE();
		m_pipe_square.Initialize();
		m_pipe_square.m_board = m_square.m_board;
		
		// make the pipe square position the same
		m_pipe_square.m_row = m_square.m_row;
		m_pipe_square.m_column = m_square.m_column;
		
		// now attach this square to the top and bottom of the actual square
		m_pipe_square.m_above = m_square.m_above;
		m_pipe_square.m_below = m_square.m_below;
		
		// but left and right point to this pipes square
		m_pipe_square.m_left = m_square;
		m_pipe_square.m_right = m_square;
		
		// now point the above and below squares to this new square.
		m_square.m_above.m_below = m_pipe_square;
		m_square.m_below.m_above = m_pipe_square;

		// set pipe flow direction
		m_pipe_square.m_pipe_flow_down_direction = DIRECTION.DOWN;
		m_pipe_square.m_pipe_flow_up_direction = DIRECTION.UP;
		m_pipe_square.m_pipe_flow_speed = 3.0f;
		m_pipe_square.m_pipe = true;
	}
	
	public override void Process()
	{
		// do not need to be processed because they don't 
		// do anything by themselves so deactivate
		m_square.m_active = false;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void Process_Move()
	{
		// doesn't need to move
	}
};

public class PIPE_HORIZONTAL: OBJECT
{
	SQUARE m_pipe_square;
	DIRECTION m_direction;
	
	public DIRECTION OppositeDirection(DIRECTION direction)
	{
		switch(direction)
		{
			case DIRECTION.UP:
				return DIRECTION.DOWN;
			case DIRECTION.DOWN:
				return DIRECTION.UP;
			case DIRECTION.RIGHT:
				return DIRECTION.LEFT;
			case DIRECTION.LEFT:
				return DIRECTION.RIGHT;
			case DIRECTION.NONE:
				return DIRECTION.NONE;
			default:
				return DIRECTION.NONE;
		}
	}
	
	private PIPE_HORIZONTAL()
	{
		m_direction = DIRECTION.NONE;
	}
	
	public PIPE_HORIZONTAL(DIRECTION direction)
	{
		m_direction = direction;
	}
	
	public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}
	
	public override void Initialize()
	{
		Initialize_Object();
		
		m_game_object = GameObject.Instantiate(Resources.Load("Pipe"), Vector3.zero, Quaternion.identity) as GameObject;
		m_game_object.transform.Rotate (Vector3.forward, 90, Space.World);
	}
	
	public override void SetSquare(SQUARE square)
	{
		// assigned my square
		m_square = square;
		
		// create a new square to carry piped items
		m_pipe_square = new SQUARE();
		m_pipe_square.Initialize();
		m_pipe_square.m_board = m_square.m_board;
		
		// make the pipe square position the same
		m_pipe_square.m_row = m_square.m_row;
		m_pipe_square.m_column = m_square.m_column;
		
		// now attach this square to the left and right of the actual square
		m_pipe_square.m_left = m_square.m_left;
		m_pipe_square.m_right = m_square.m_right;
		
		// but above and below point to this pipes square
		m_pipe_square.m_above = m_square;
		m_pipe_square.m_below = m_square;
		
		// now point the left and right squares to this new square.
		m_square.m_left.m_right = m_pipe_square;
		m_square.m_right.m_left = m_pipe_square;
		
		// set pipe flow direction
		m_pipe_square.m_pipe_flow_down_direction = m_direction;
		m_pipe_square.m_pipe_flow_up_direction = OppositeDirection(m_direction);
		m_pipe_square.m_pipe_flow_speed = 3.0f;
		m_pipe_square.m_pipe = true;
	}
	
	public override void Process()
	{
		// do not need to be processed because they don't 
		// do anything by themselves so deactivate
		m_square.m_active = false;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void Process_Move()
	{
		// doesn't need to move
	}
};

public class PIPE_ELBOW_LEFT: OBJECT
{
	SQUARE m_pipe_square;
	
	public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}
	
	public override void Initialize()
	{
		Initialize_Object();

		m_round = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Pipe Elbow"), Vector3.zero, Quaternion.identity) as GameObject;
		m_game_object.transform.Rotate (Vector3.right, 90, Space.World);
		m_game_object.transform.Rotate (Vector3.up, 90, Space.World);
	}
	
	public override void Process()
	{
		// do not need to be processed because they don't 
		// do anything by themselves so deactivate
		m_square.m_active = false;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void SetSquare(SQUARE square)
	{
		// assigned my square
		m_square = square;
		
		// create a new square to carry piped items
		m_pipe_square = new SQUARE();
		m_pipe_square.Initialize();
		m_pipe_square.m_board = m_square.m_board;
		
		// make the pipe square position the same
		m_pipe_square.m_row = m_square.m_row;
		m_pipe_square.m_column = m_square.m_column;
		
		// now attach this square to the left and below of the actual square
		m_pipe_square.m_left = m_square.m_left;
		m_pipe_square.m_below = m_square.m_below;
		
		// but above and right point to this pipes square
		m_pipe_square.m_above = m_square;
		m_pipe_square.m_right = m_square;
		
		// now point the left and below squares to this new square.
		m_square.m_left.m_right = m_pipe_square;
		m_square.m_below.m_above = m_pipe_square;
		
		// set pipe flow direction
		m_pipe_square.m_pipe_flow_down_direction = DIRECTION.DOWN;
		m_pipe_square.m_pipe_flow_up_direction = DIRECTION.LEFT;
		m_pipe_square.m_pipe = true;
		m_pipe_square.m_pipe_flow_speed = 3.0f;
	}
	
	public override void Process_Move()
	{
		// doesn't need to move
	}
};

public class PIPE_ELBOW_ABOVE: OBJECT
{
	SQUARE m_pipe_square;
	
	public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}
	
	public override void Initialize()
	{
		Initialize_Object();

		m_round = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Pipe Elbow"), Vector3.zero, Quaternion.identity) as GameObject;
		m_game_object.transform.Rotate (Vector3.right, 90, Space.World);
		m_game_object.transform.Rotate (Vector3.forward, 180, Space.World);
		m_game_object.transform.Rotate (Vector3.up, 90, Space.World);
	}
	
	public override void SetSquare(SQUARE square)
	{
		// assigned my square
		m_square = square;
		
		// create a new square to carry piped items
		m_pipe_square = new SQUARE();
		m_pipe_square.Initialize();
		m_pipe_square.m_board = m_square.m_board;
		
		// make the pipe square position the same
		m_pipe_square.m_row = m_square.m_row;
		m_pipe_square.m_column = m_square.m_column;
		
		// now attach this square to the left and above of the actual square
		m_pipe_square.m_left = m_square.m_left;
		m_pipe_square.m_above = m_square.m_above;
		
		// but below and right point to this pipes square
		m_pipe_square.m_below = m_square;
		m_pipe_square.m_right = m_square;
		
		// now point the left and above squares to this new square.
		m_square.m_left.m_right = m_pipe_square;
		m_square.m_above.m_below = m_pipe_square;

		// set pipe flow direction
		m_pipe_square.m_pipe_flow_down_direction = DIRECTION.LEFT;
		m_pipe_square.m_pipe_flow_up_direction = DIRECTION.UP;
		m_pipe_square.m_pipe = true;
		m_pipe_square.m_pipe_flow_speed = 3.0f;
	}
	
	public override void Process()
	{
		// do not need to be processed because they don't 
		// do anything by themselves so deactivate
		m_square.m_active = false;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void Process_Move()
	{
		// doesn't need to move
	}
};

public class PIPE_ELBOW_RIGHT: OBJECT
{
	SQUARE m_pipe_square;
	
	public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}
	
	public override void Initialize()
	{
		Initialize_Object();

		m_round = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Pipe Elbow"), Vector3.zero, Quaternion.identity) as GameObject;
		m_game_object.transform.Rotate (Vector3.right, 270, Space.World);
		m_game_object.transform.Rotate (Vector3.forward, 180, Space.World);
		m_game_object.transform.Rotate (Vector3.up, 90, Space.World);
	}
	
	public override void SetSquare(SQUARE square)
	{
		// assigned my square
		m_square = square;
		
		// create a new square to carry piped items
		m_pipe_square = new SQUARE();
		m_pipe_square.Initialize();
		m_pipe_square.m_board = m_square.m_board;
		
		// make the pipe square position the same
		m_pipe_square.m_row = m_square.m_row;
		m_pipe_square.m_column = m_square.m_column;
		
		// now attach this square to the left and above of the actual square
		m_pipe_square.m_right = m_square.m_right;
		m_pipe_square.m_below = m_square.m_below;
		
		// but below and right point to this pipes square
		m_pipe_square.m_above = m_square;
		m_pipe_square.m_left = m_square;
		
		// now point the left and above squares to this new square.
		m_square.m_right.m_left = m_pipe_square;
		m_square.m_below.m_above = m_pipe_square;

		// set pipe flow direction
		m_pipe_square.m_pipe_flow_down_direction = DIRECTION.DOWN;;
		m_pipe_square.m_pipe_flow_up_direction = DIRECTION.RIGHT;
		m_pipe_square.m_pipe = true;
		m_pipe_square.m_pipe_flow_speed = 3.0f;
	}
	
	public override void Process()
	{
		// do not need to be processed because they don't 
		// do anything by themselves so deactivate
		m_square.m_active = false;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void Process_Move()
	{
		// doesn't need to move
	}
};

public class PIPE_ELBOW_DOWN: OBJECT
{
	SQUARE m_pipe_square;
	
	public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}
	
	public override void Initialize()
	{
		Initialize_Object();

		m_round = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Pipe Elbow"), Vector3.zero, Quaternion.identity) as GameObject;
		m_game_object.transform.Rotate (Vector3.right, 180, Space.World);
		m_game_object.transform.Rotate (Vector3.forward, 0, Space.World);
		m_game_object.transform.Rotate (Vector3.up, 270, Space.World);
	}
	
	public override void SetSquare(SQUARE square)
	{
		// assigned my square
		m_square = square;
		
		// create a new square to carry piped items
		m_pipe_square = new SQUARE();
		m_pipe_square.Initialize();
		m_pipe_square.m_board = m_square.m_board;
		
		// make the pipe square position the same
		m_pipe_square.m_row = m_square.m_row;
		m_pipe_square.m_column = m_square.m_column;
		
		// now attach this square to the left and above of the actual square
		m_pipe_square.m_right = m_square.m_right;
		m_pipe_square.m_above = m_square.m_above;
		
		// but below and right point to this pipes square
		m_pipe_square.m_below = m_square;
		m_pipe_square.m_left = m_square;
		
		// now point the left and above squares to this new square.
		m_square.m_right.m_left = m_pipe_square;
		m_square.m_above.m_below = m_pipe_square;

		// set pipe flow direction
		m_pipe_square.m_pipe_flow_down_direction = DIRECTION.RIGHT;;
		m_pipe_square.m_pipe_flow_up_direction = DIRECTION.UP;
		m_pipe_square.m_pipe = true;
		m_pipe_square.m_pipe_flow_speed = 3.0f;
	}
	
	public override void Process()
	{
		// do not need to be processed because they don't 
		// do anything by themselves so deactivate
		m_square.m_active = false;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void Process_Move()
	{
		// doesn't need to move
	}
};

public class PIPE_4WAY: OBJECT
{
	SQUARE m_pipe_square;
	
	public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}
	
	public override void Initialize()
	{
		Initialize_Object();

		m_round = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Pipe 4 way"), Vector3.zero, Quaternion.identity) as GameObject;
		m_game_object.transform.Rotate (Vector3.up, 90, Space.World);
	}
	
	public override void SetSquare(SQUARE square)
	{
		// assigned my square
		m_square = square;
		
		// create a new square to carry piped items
		m_pipe_square = new SQUARE();
		m_pipe_square.Initialize();
		m_pipe_square.m_board = m_square.m_board;
		
		// make the pipe square position the same
		m_pipe_square.m_row = m_square.m_row;
		m_pipe_square.m_column = m_square.m_column;
		
		// now attach this square to the left and above of the actual square
		m_pipe_square.m_left = m_square.m_left;
		m_pipe_square.m_above = m_square.m_above;
		m_pipe_square.m_right = m_square.m_right;
		m_pipe_square.m_below = m_square.m_below;
				
		// now point the left and above squares to this new square.
		m_square.m_left.m_right = m_pipe_square;
		m_square.m_above.m_below = m_pipe_square;
		m_square.m_right.m_left = m_pipe_square;
		m_square.m_below.m_above = m_pipe_square;

		// set pipe flow direction
		m_pipe_square.m_pipe_flow_down_direction = DIRECTION.DOWN;
		m_pipe_square.m_pipe_flow_up_direction = DIRECTION.UP;
		m_pipe_square.m_pipe = true;
		m_pipe_square.m_pipe_flow_speed = 3.0f;
	}
	
	public override void Process()
	{
		// do not need to be processed because they don't 
		// do anything by themselves so deactivate
		m_square.m_active = false;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void Process_Move()
	{
		// doesn't need to move
	}
};

public class PIPE_3WAY: OBJECT
{
	SQUARE m_pipe_square;
	
	public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}
	
	public override void Initialize()
	{
		Initialize_Object();

		m_round = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Pipe 3 way"), Vector3.zero, Quaternion.identity) as GameObject;
		m_game_object.transform.Rotate (Vector3.up, 90, Space.World);
	}
	
	public override void SetSquare(SQUARE square)
	{
		// assigned my square
		m_square = square;
		
		// create a new square to carry piped items
		m_pipe_square = new SQUARE();
		m_pipe_square.Initialize();
		m_pipe_square.m_board = m_square.m_board;
		
		// make the pipe square position the same
		m_pipe_square.m_row = m_square.m_row;
		m_pipe_square.m_column = m_square.m_column;
		
		// now attach this square to the left and above of the actual square
		m_pipe_square.m_above = m_square.m_above;
		m_pipe_square.m_right = m_square.m_right;
		m_pipe_square.m_below = m_square.m_below;
				
		// now point the left and above squares to this new square.
		m_square.m_above.m_below = m_pipe_square;
		m_square.m_right.m_left = m_pipe_square;
		m_square.m_below.m_above = m_pipe_square;

		m_pipe_square.m_left = m_square;
		
		// set pipe flow direction
		m_pipe_square.m_pipe_flow_down_direction = DIRECTION.DOWN;
		m_pipe_square.m_pipe_flow_up_direction = DIRECTION.UP;
		m_pipe_square.m_pipe = true;
		m_pipe_square.m_pipe_flow_speed = 3.0f;
	}
	
	public override void Process()
	{
		// do not need to be processed because they don't 
		// do anything by themselves so deactivate
		m_square.m_active = false;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void Process_Move()
	{
		// doesn't need to move
	}
};

public class AMOEBA: OBJECT
{
    public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}

	public override bool Drill()
	{
		m_square.m_board.Remove_Object(this);
		
		m_square.Activate_All_Around_Square();
		
		return true;
	}
	
	public override bool Explode()
	{
		BALLOON ballon;
		ballon = new BALLOON();
		ballon.Initialize();
		m_square.m_board.Place_Object(ballon, m_square);
				
		m_square.Activate_All_Around_Square();
		
		return true;
	}

	public override void Initialize()
	{
		Initialize_Object();
		
		m_drillable = true;
		m_explodeable = true;
		m_drillable = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("AMOEBA"), Vector3.zero, Quaternion.identity) as GameObject;
	}
	
	public override void Process()
	{
		int percent = Random.Range(0, 10000);
		
		// need to make this time based
		if (percent > 9995)
		{
			// randomly create more around me
			DIRECTION direction = (DIRECTION)Random.Range(0, 4);
			
			SQUARE square = m_square.Get_Square_Forward(direction);
			if (square.Occupied() == false)
			{
				AMOEBA amoeba = new AMOEBA();
				amoeba.Initialize();
				m_square.m_board.Place_Object(amoeba, square);
				//amoeba = null;
			}
		}
		
		// they are always active and spreading, otherwise they only spread where there is activity
		m_square.m_active = true;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void Process_Move()
	{
		// they don't move
	}
};

public class LAVA: OBJECT
{
    public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}
	
	public override bool Explode()
	{
		LAVA_STONE box;
		box = new LAVA_STONE();
		box.Initialize();
		m_square.m_board.Place_Object(box, m_square);

		m_square.Activate_All_Around_Square();
		
		return true;	
	}

	public override void Initialize()
	{
		Initialize_Object();
		
		m_explodeable = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Lava"), Vector3.zero, Quaternion.identity) as GameObject;
	}
	
	public override void Process()
	{
		int percent = Random.Range(0, 10000);
		
		// need to make this time based
		if (percent > 9995)
		{
			// randomly create more around me
			DIRECTION direction = (DIRECTION)Random.Range(0, 4);
			
			SQUARE square = m_square.Get_Square_Forward(direction);
			if (square.Occupied() == false)
			{
				LAVA lava = new LAVA();
				lava.Initialize();
				m_square.m_board.Place_Object(lava, square);
				//amoeba = null;
			}
		}
		
		// they are always active and spreading, otherwise they only spread where there is activity
		m_square.m_active = true;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void Process_Move()
	{
		// they don't move
	}
};


public class STONE: OBJECT
{
    public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}

	public override void Initialize()
	{
		Initialize_Object();

		m_game_object = GameObject.Instantiate(Resources.Load("Stone"), Vector3.zero, Quaternion.identity) as GameObject;
	}
	
	public override void Process()
	{
		// bricks do not need to be processed because they don't 
		// do anything by themselves so deactivate
		m_square.m_active = false;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void Process_Move()
	{
		// bricks don't move
	}
};

public class STONE_BREAKABLE2: OBJECT
{
	public override bool Drill()
	{
		m_square.m_board.Remove_Object(this);
		
		m_square.Activate_All_Around_Square();
		
		return true;
	}

 	public override bool Explode()
	{
		m_square.m_board.Remove_Object(this);
		
		m_square.Activate_All_Around_Square();
		
		return true;
	}

    public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}

	public override void Initialize()
	{
		Initialize_Object();
		
		m_drillable = true;
		m_explodeable = true;
		m_drillable = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Stone Breakable"), Vector3.zero, Quaternion.identity) as GameObject;
	}
	
	public override void Process()
	{
		// bricks do not need to be processed because they don't 
		// do anything by themselves so deactivate
		m_square.m_active = false;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void Process_Move()
	{
		// bricks don't move
	}
};

public class STONE_BREAKABLE: OBJECT
{
	public override bool Drill()
	{
		STONE_BREAKABLE2 box;
		box = new STONE_BREAKABLE2();
		box.Initialize();
		m_square.m_board.Place_Object(box, m_square);

		m_square.Activate_All_Around_Square();
		
		return true;
	}

	public override bool Explode()
	{
		STONE_BREAKABLE2 box;
		box = new STONE_BREAKABLE2();
		box.Initialize();
		m_square.m_board.Place_Object(box, m_square);

		m_square.Activate_All_Around_Square();
		
		return true;
	}

    public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}

	public override void Initialize()
	{
		Initialize_Object();
		
		m_drillable = true;
		m_explodeable = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Stone"), Vector3.zero, Quaternion.identity) as GameObject;
	}
	
	public override void Process()
	{
		// bricks do not need to be processed because they don't 
		// do anything by themselves so deactivate
		m_square.m_active = false;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void Process_Move()
	{
		// bricks don't move
	}
};

public class ROCK: OBJECT
{
    public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}

	public override bool Explode()
	{
		ROCK_BOX box;
		box = new ROCK_BOX();
		box.Initialize();
		m_square.m_board.Place_Object(box, m_square);

		m_square.Activate_All_Around_Square();
		
		return true;
	}

	public override void Initialize()
	{
		Initialize_Object();

		m_explodeable = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Rock"), Vector3.zero, Quaternion.identity) as GameObject;
	}
	
	public override void Process()
	{
		// bricks do not need to be processed because they don't 
		// do anything by themselves so deactivate
		m_square.m_active = false;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void Process_Move()
	{
		// bricks don't move
	}
};

public class MAGIC: OBJECT
{
	SQUARE m_magic_square;
	OBJECT m_last_object;
	
    public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}

	public override void Initialize()
	{
		Initialize_Object();
		
		m_last_object = null;

		m_game_object = GameObject.Instantiate(Resources.Load("Magic"), Vector3.zero, Quaternion.identity) as GameObject;
	}
	
	public override void Process()
	{
		// bricks do not need to be processed because they don't 
		// do anything by themselves so deactivate
		m_square.m_active = true;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
		
		if ((m_magic_square.Occupied() == true) && (m_magic_square.m_object != m_last_object) && (m_magic_square.m_object.m_new_square != m_magic_square))
		{
			if (m_magic_square.m_object is CRYSTAL)
			{
				// remove the object first in case it is moving between squares
				m_magic_square.m_board.Remove_Object(m_magic_square.m_object);
				
				// putting a cystal in the center will stop a ball rolling down so it will not crush the item below it
				ROCK_BALL rock_ball = new ROCK_BALL();
				rock_ball.Initialize();
				m_magic_square.m_board.Place_Object(rock_ball, m_magic_square);
				
				m_last_object = rock_ball;
			}
			else if (m_magic_square.m_object is ROCK_BALL)
			{
				// remove the object first in case it is moving between squares
				m_magic_square.m_board.Remove_Object(m_magic_square.m_object);
				
				// putting a cystal in the center will stop a ball rolling down so it will not crush the item below it
				CRYSTAL crystal = new CRYSTAL();
				crystal.Initialize();
				m_magic_square.m_board.Place_Object(crystal, m_magic_square);

				m_last_object = crystal;
			}
			else if (m_magic_square.m_object is ROCK_MONSTER)
			{
				// remove the object first in case it is moving between squares
				m_magic_square.m_board.Remove_Object(m_magic_square.m_object);
				
				// putting a cystal in the center will stop a ball rolling down so it will not crush the item below it
				CRYSTAL crystal = new CRYSTAL();
				crystal.Initialize();
				m_magic_square.m_board.Place_Object(crystal, m_magic_square);

				m_last_object = crystal;
			}
			else if (m_magic_square.m_object is SOFT_ROCK_BALL)
			{
				// remove the object first in case it is moving between squares
				m_magic_square.m_board.Remove_Object(m_magic_square.m_object);
				
				// putting a cystal in the center will stop a ball rolling down so it will not crush the item below it
				CRYSTAL crystal = new CRYSTAL();
				crystal.Initialize();
				m_magic_square.m_board.Place_Object(crystal, m_magic_square);

				m_last_object = crystal;
			}
			else if (m_magic_square.m_object is STONE_BALL)
			{
				// remove the object first in case it is moving between squares
				m_magic_square.m_board.Remove_Object(m_magic_square.m_object);
				
				// putting a cystal in the center will stop a ball rolling down so it will not crush the item below it
				CRYSTAL crystal = new CRYSTAL();
				crystal.Initialize();
				m_magic_square.m_board.Place_Object(crystal, m_magic_square);

				m_last_object = crystal;
			}
		}
	}
	
	public override void SetSquare(SQUARE square)
	{
		// assigned my square
		m_square = square;
		
		// create a new square to carry items
		m_magic_square = new SQUARE();
		m_magic_square.Initialize();
		m_magic_square.m_board = m_square.m_board;
		
		// make the square position the same
		m_magic_square.m_row = m_square.m_row;
		m_magic_square.m_column = m_square.m_column;
		
		// point all the sqaures to just point to where the original square pointed so the space becomes pass thru
		m_magic_square.m_left = m_square.m_left;
		m_magic_square.m_right = m_square.m_right;
		m_magic_square.m_above = m_square.m_above;
		m_magic_square.m_below = m_square.m_below;
		
		// point all the the surrounding squares to the square instead of original square (TODO: teleporters are not handled right here)
		m_magic_square.m_left.m_right = m_magic_square;
		m_magic_square.m_right.m_left = m_magic_square;
		m_magic_square.m_above.m_below = m_magic_square;
		m_magic_square.m_below.m_above = m_magic_square;
	}
	
	public override void Process_Move()
	{
		if (m_magic_square.Occupied() == true)
		{
			if (m_magic_square.m_object is CRYSTAL)
			{
				// remove the object first in case it is moving between squares
				m_magic_square.m_board.Remove_Object(m_magic_square.m_object);
				
				// putting a cystal in the center will stop a ball rolling down so it will not crush the item below it
				ROCK_BALL rock_ball = new ROCK_BALL();
				rock_ball.Initialize();
				m_magic_square.m_board.Place_Object(rock_ball, m_magic_square);
			}
			
			if (m_magic_square.m_object is ROCK_BALL)
			{
				// remove the object first in case it is moving between squares
				m_magic_square.m_board.Remove_Object(m_magic_square.m_object);
				
				// putting a cystal in the center will stop a ball rolling down so it will not crush the item below it
				CRYSTAL crystal = new CRYSTAL();
				crystal.Initialize();
				m_magic_square.m_board.Place_Object(crystal, m_magic_square);
			}
		}
	}
};

public class BOMB: OBJECT
{
	float m_time_created;
	AudioClip m_bomb_sound;
	AudioClip m_fuse_sound;
	
    public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}

	public override bool Explode()
	{
		Vector3 save_position = m_game_object.transform.position;
		
		m_square.m_board.Remove_Object(this);
		
		// explode all the squares around this square
		if ((m_square.m_right.m_above.m_object != null) && (m_square.m_right.m_above.m_object.m_explodeable == true))
			m_square.m_right.m_above.m_object.Explode();
		if ((m_square.m_right.m_below.m_object != null) && (m_square.m_right.m_below.m_object.m_explodeable == true))
			m_square.m_right.m_below.m_object.Explode();
		if ((m_square.m_left.m_above.m_object != null) && (m_square.m_left.m_above.m_object.m_explodeable == true))
			m_square.m_left.m_above.m_object.Explode();
		if ((m_square.m_left.m_below.m_object != null) && (m_square.m_left.m_below.m_object.m_explodeable == true))
			m_square.m_left.m_below.m_object.Explode();

		if ((m_square.m_above.m_object != null) && (m_square.m_above.m_object.m_explodeable == true))
			m_square.m_above.m_object.Explode();
		if ((m_square.m_below.m_object != null) && (m_square.m_below.m_object.m_explodeable == true))
			m_square.m_below.m_object.Explode();
		if ((m_square.m_left.m_object != null) && (m_square.m_left.m_object.m_explodeable == true))
			m_square.m_left.m_object.Explode();
		if ((m_square.m_right.m_object != null) && (m_square.m_right.m_object.m_explodeable == true))
			m_square.m_right.m_object.Explode();
		
		/*
		if ((m_square.m_above.m_right.m_object != null) && (m_square.m_above.m_right.m_object.m_explodeable == true))
			m_square.m_above.m_right.m_object.Explode();
		if ((m_square.m_above.m_left.m_object != null) && (m_square.m_above.m_left.m_object.m_explodeable == true))
			m_square.m_above.m_left.m_object.Explode();
		if ((m_square.m_below.m_right.m_object != null) && (m_square.m_below.m_right.m_object.m_explodeable == true))
			m_square.m_below.m_right.m_object.Explode();
		if ((m_square.m_below.m_left.m_object != null) && (m_square.m_below.m_left.m_object.m_explodeable == true))
			m_square.m_below.m_left.m_object.Explode();
*/
		m_square.Activate_All_Around_Square();
		
		AudioSource.PlayClipAtPoint(m_bomb_sound, save_position);

		return true;
	}

	public override void Initialize()
	{
		Initialize_Object();

		m_round = true;
		m_explodeable = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Bomb"), Vector3.zero, Quaternion.identity) as GameObject;
		m_bomb_sound = MINE_AUDIO.Instance.m_bomb_sound;
		m_fuse_sound = MINE_AUDIO.Instance.m_fuse_sound;
		
		// start the fuse sound
		m_game_object.GetComponent<AudioSource>().loop = true;
		m_game_object.GetComponent<AudioSource>().clip = m_fuse_sound;
		m_game_object.GetComponent<AudioSource>().Play();

		m_time_created = Time.time;
	}
	
	public override void Process()
	{
		m_square.m_active = true;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
		
		// fuse is 5 seconds long
		if ((Time.time - m_time_created) > 5.0f)
		{
			// stop the fuse sound and then explode
			m_game_object.GetComponent<AudioSource>().Stop();
			Explode();
		}
		else
		{
			if ((m_square.m_conveyor_belt == true) &&
				(m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction).Occupied() == false))			
			{
				m_square.m_board.Start_Move_Object(this, m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction), m_square.m_conveyor_belt_direction, m_square.m_conveyor_belt_speed, false);
			}
			else if ((m_square.m_pipe == true) &&
				(m_square.Get_Square_Forward(m_square.m_pipe_flow_down_direction).Occupied() == false))
			{
				// we are in a pipe, let's try going with the flow
				m_square.m_board.Start_Move_Object(this, m_square.Get_Square_Forward(m_square.m_pipe_flow_down_direction), m_square.m_pipe_flow_down_direction, m_square.m_pipe_flow_speed, true);
			}
		}
	}
	
	public override void Process_Move()
	{
		Process_Move_For_Stationary_Objects();
	}
};

public class KEY: OBJECT
{
	OBJECT_COLOR m_color;
	
    public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}
	
	public KEY(OBJECT_COLOR color)
	{
		m_color = color;
	}

	public override bool Pickup(OBJECT pickuper)
	{
		m_square.m_board.Remove_Object(this);
		switch (m_color)
		{
			case OBJECT_COLOR.GREEN:
			SCORE.m_number_of_green_keys++;
				break;
			case OBJECT_COLOR.YELLOW:
			SCORE.m_number_of_yellow_keys++;
				break;
			case OBJECT_COLOR.BLUE:
			SCORE.m_number_of_blue_keys++;
				break;
			case OBJECT_COLOR.RED:
			SCORE.m_number_of_red_keys++;
			break;
		}
		
		return true;
	}
	
	public override void Initialize()
	{
		Initialize_Object();

		m_round = true;
		m_pickupable = true;
		
		switch (m_color)
		{
			case OBJECT_COLOR.GREEN:
			m_game_object = GameObject.Instantiate(Resources.Load("Key Green"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			case OBJECT_COLOR.YELLOW:
			m_game_object = GameObject.Instantiate(Resources.Load("Key Yellow"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			case OBJECT_COLOR.BLUE:
			m_game_object = GameObject.Instantiate(Resources.Load("Key Blue"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			case OBJECT_COLOR.RED:
			m_game_object = GameObject.Instantiate(Resources.Load("Key Red"), Vector3.zero, Quaternion.identity) as GameObject;
			break;
		}
		
//		m_game_object.transform.Rotate (Vector3.left, 90, Space.World);
		m_game_object.transform.Rotate (Vector3.forward, 90, Space.World);
//		m_game_object.transform.Rotate (Vector3.down, 90, Space.World);
	}
	
	public override void Process()
	{
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void Process_Move()
	{
		Process_Move_For_Stationary_Objects();
	}
};

public class INGOTS: OBJECT
{
	AudioClip m_pickup_sound;
	ORE m_ore;
	
	public enum ORE {GOLD, SILVER, IRON, PLATNUM, COPPER, NICKLE}
	
    public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}
	
	public INGOTS(ORE ore)
	{
		m_ore = ore;
	}

	public override bool Pickup(OBJECT pickuper)
	{
		Vector3 save_position = m_game_object.transform.position;
		
		m_square.m_board.Remove_Object(this);
		
		switch(m_ore)
		{
			case ORE.COPPER:
				SCORE.m_score_point_this_level++;
				break;
			case ORE.GOLD:
				SCORE.m_score_point_this_level++;
				break;
			case ORE.SILVER:
				SCORE.m_score_point_this_level++;
				break;
			case ORE.IRON:
				SCORE.m_score_point_this_level++;
				break;
			case ORE.PLATNUM:
				SCORE.m_score_point_this_level++;
				break;
			case ORE.NICKLE:
				SCORE.m_score_point_this_level++;
				break;
			default:
				SCORE.m_score_point_this_level++;
				break;
		}
		
		AudioSource.PlayClipAtPoint(m_pickup_sound, save_position);
		
		m_square.Activate_All_Around_Square();
		
		return true;
	}
	
	public override void Initialize()
	{
		Initialize_Object();

		m_round = true;
		m_pickupable = true;
		
		switch (m_ore)
		{
			case ORE.GOLD:	
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Ingots Gold"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}	
			case ORE.COPPER:	
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Ingots Copper"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}
			case ORE.SILVER:	
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Ingots Silver"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}	
			case ORE.IRON:	
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Ingots Iron"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}	
			case ORE.NICKLE:	
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Ingots Nickle"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}	
			case ORE.PLATNUM:	
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Ingots Platnum"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}
			default:
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Ingots Copper"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}
		}
		
		m_pickup_sound = MINE_AUDIO.Instance.m_pickup_sound;
		
		m_game_object.transform.Rotate (Vector3.left, 180, Space.World);
//		m_game_object.transform.Rotate (Vector3.forward, 90, Space.World);
//		m_game_object.transform.Rotate (Vector3.down, 90, Space.World);
	}
	
	public override void Process()
	{
		//Process_For_Stationary_Objects();
	}
	
	public override void Process_Move()
	{
		Process_Move_For_Stationary_Objects();
	}
};

public class LAVA_STONE_BOX: OBJECT
{
	public override bool Explode()
	{
		// we need to make sure the box is not moving before we change it to a ball as we could end up with both a box and a ball and remove the player if we are not careful
		if (m_new_square == null)
		{
			LAVA_STONE_BALL ball;
			ball = new LAVA_STONE_BALL();
			ball.Initialize();
			m_square.m_board.Place_Object(ball, m_square);
			
			m_square.Activate_All_Around_Square();
			
			return true;
		}
		else
		{
			return false;
		}
	}

	public override void Initialize()
	{
		Initialize_Object();

		m_pushable = true;
		m_explodeable = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Lava Stone Box"), Vector3.zero, Quaternion.identity) as GameObject;
	}
	
	public override void Process()
	{
		if ((m_square.m_conveyor_belt == true) &&
			(m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction).Occupied() == false) &&
			(m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction).m_pipe == false))
		{
			m_square.m_board.Start_Move_Object(this, m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction), m_square.m_conveyor_belt_direction, m_square.m_conveyor_belt_speed, false);
			m_square.m_active = true;
		}
		else
		{
			// boxes do not need to be processed because they don't 
			// do anything by themselves so deactivate
			m_square.m_active = false;
			m_horizontal_velocity = 0;
			m_verticle_velocity = 0;
		}
	}
	
	public override void Process_Move()
	{
		Process_Move_For_Stationary_Objects();
	}
};

public class LAVA_STONE: OBJECT
{
    public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}

	public override bool Explode()
	{
		LAVA_STONE_BOX box;
		box = new LAVA_STONE_BOX();
		box.Initialize();
		m_square.m_board.Place_Object(box, m_square);

		m_square.Activate_All_Around_Square();
		
		return true;
	}

	public override void Initialize()
	{
		Initialize_Object();

		m_explodeable = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Lava Stone"), Vector3.zero, Quaternion.identity) as GameObject;
	}
	
	public override void Process()
	{
		// bricks do not need to be processed because they don't 
		// do anything by themselves so deactivate
		m_square.m_active = false;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void Process_Move()
	{
		// bricks don't move
	}
};

public class SOFT_ROCK: OBJECT
{
    public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}

	public override bool Drill()
	{
		SOFT_ROCK_BOX box;
		box = new SOFT_ROCK_BOX();
		box.Initialize();
		m_square.m_board.Place_Object(box, m_square);

		m_square.Activate_All_Around_Square();
		
		return true;
	}

	public override bool Explode()
	{
		SOFT_ROCK_BOX box;
		box = new SOFT_ROCK_BOX();
		box.Initialize();
		m_square.m_board.Place_Object(box, m_square);

		m_square.Activate_All_Around_Square();
		
		return true;
	}

	public override void Initialize()
	{
		Initialize_Object();

		m_explodeable = true;
		m_drillable = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Soft Rock"), Vector3.zero, Quaternion.identity) as GameObject;
	}
	
	public override void Process()
	{
		// bricks do not need to be processed because they don't 
		// do anything by themselves so deactivate
		m_square.m_active = false;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void Process_Move()
	{
		// bricks don't move
	}
};

public class CRYSTAL: OBJECT
{
	float m_fall_speed;
	float m_roll_speed;
	AudioClip m_break_sound;
	AudioClip m_hit_sound;
	AudioClip m_pickup_sound;
	public enum GEM {AMETHYST, CITRINE, DIAMOND, EMERALD, GARNET, PERIDOT, RUBY, SAPPHIRE, SAPPHIRE_BLACK, TOPAZ};
	GEM m_gem;
	
	public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}

	public CRYSTAL(GEM gem)
	{
		m_gem = gem;
	}
	
	public CRYSTAL()
	{
		m_gem = (GEM)Random.Range(0,9);
	}
	
	public override bool Drill()
	{
		m_square.m_board.Remove_Object(this);
		
		m_square.Activate_All_Around_Square();
		
		return true;
	}
	
	public override bool Explode()
	{
		m_square.m_board.Remove_Object(this);
		
		m_square.Activate_All_Around_Square();
		
		return true;
	}
	
	public override bool Hit()
	{
		m_game_object.GetComponent<AudioSource>().PlayOneShot(m_hit_sound);
		return true;
	}
	
	public override bool Pickup(OBJECT pickuper)
	{
		Vector3 save_position = m_game_object.transform.position;
		
		m_square.m_board.Remove_Object(this);
		
		switch (m_gem)
		{
			case GEM.AMETHYST:	
			{
				SCORE.m_score_point_this_level++;
				break;
			}	
			case GEM.CITRINE:	
			{
				SCORE.m_score_point_this_level++;
				break;
			}	
			case GEM.DIAMOND:	
			{
				SCORE.m_score_point_this_level++;
				break;
			}	
			case GEM.EMERALD:	
			{
				SCORE.m_score_point_this_level++;
				break;
			}
			case GEM.GARNET:	
			{
				SCORE.m_score_point_this_level++;
				break;
			}	
			case GEM.PERIDOT:	
			{
				SCORE.m_score_point_this_level++;
				break;
			}	
			case GEM.RUBY:	
			{
				SCORE.m_score_point_this_level++;
				break;
			}	
			case GEM.SAPPHIRE:	
			{
				SCORE.m_score_point_this_level++;
				break;
			}	
			case GEM.SAPPHIRE_BLACK:	
			{
				SCORE.m_score_point_this_level++;
				break;
			}	
			case GEM.TOPAZ:	
			{
				SCORE.m_score_point_this_level++;
				break;
			}
		}
		
		m_square.Activate_All_Around_Square();
		
		AudioSource.PlayClipAtPoint(m_pickup_sound, save_position);

		return true;
	}
	
	public override void Initialize()
	{
		Initialize_Object();

		m_break_sound = MINE_AUDIO.Instance.m_crystal_break_sound;
		m_hit_sound = MINE_AUDIO.Instance.m_crystal_hit_sound;
		m_pickup_sound = MINE_AUDIO.Instance.m_pickup_sound;
		
		m_round = true;
		m_pickupable = true;
		m_hitable = true;
		m_crushable = true;
		m_explodeable = true;
		m_drillable = true;
		
		switch (m_gem)
		{
			case GEM.AMETHYST:	
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Crystal Amethyst"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}	
			case GEM.CITRINE:	
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Crystal Citrine"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}	
			case GEM.DIAMOND:	
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Crystal Diamond"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}	
			case GEM.EMERALD:	
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Crystal Emerald"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}
			case GEM.GARNET:	
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Crystal Garnet"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}	
			case GEM.PERIDOT:	
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Crystal Peridot"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}	
			case GEM.RUBY:	
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Crystal Ruby"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}	
			case GEM.SAPPHIRE:	
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Crystal Sapphire"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}	
			case GEM.SAPPHIRE_BLACK:	
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Crystal Sapphire Black"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}	
			case GEM.TOPAZ:	
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Crystal Topaz"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}	
			default:
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Crystal Ruby"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}
		}
		
		m_fall_speed = 3.0f;
		m_roll_speed = 2.0f;
		
		Rotate_X(Random.Range(0,360));
		Rotate_Y(Random.Range(0,360));
		Rotate_Z(Random.Range(0,360));
	}
	
	public override void Process()
	{
		Process_For_Round_Falling_Objects(m_fall_speed, m_roll_speed);
	}
	
	public override void Process_Move()
	{
		Process_Move_For_Round_Falling_Objects();
	}
	
	public override bool Crush()
	{
		// need to play the sound separate from the object as we are about to destroy the object
		AudioSource.PlayClipAtPoint(m_break_sound, m_game_object.transform.position);
		
		m_square.m_board.Remove_Object(this);

		// question: why don't we want to activate after a crystal is crushed, if a monster it below it, 
		// it will immediately get crushed also for some reason. Why should activation matter? Need to figure this out.
		
		//m_square.Activate();

		return true;
	}
};

public class NUGGET: OBJECT
{
	public enum ORE {GOLD, SILVER, IRON, PLATNUM, COPPER, NICKLE}
	public ORE m_ore;
	float m_fall_speed;
	float m_roll_speed;
	AudioClip m_pickup_sound;
	
	public NUGGET(ORE ore)
	{
		m_ore = ore;
	}
	
	public NUGGET()
	{
		m_ore = (ORE)Random.Range(0,2); // TODO add other metals
	}
	
	public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}
	
	public override bool Pickup(OBJECT pickuper)
	{
		Vector3 save_position = m_game_object.transform.position;
		
		m_square.m_board.Remove_Object(this);
		
		switch(m_ore)
		{
			case ORE.COPPER:
				SCORE.m_score_point_this_level++;
				break;
			case ORE.GOLD:
				SCORE.m_score_point_this_level++;
				break;
			case ORE.SILVER:
				SCORE.m_score_point_this_level++;
				break;
			case ORE.IRON:
				SCORE.m_score_point_this_level++;
				break;
			case ORE.PLATNUM:
				SCORE.m_score_point_this_level++;
				break;
			case ORE.NICKLE:
				SCORE.m_score_point_this_level++;
				break;
			default:
				SCORE.m_score_point_this_level++;
				break;
		}
		
		AudioSource.PlayClipAtPoint(m_pickup_sound, save_position);
		
		m_square.Activate_All_Around_Square();
		
		return true;
	}
	
	public override void Initialize()
	{
		Initialize_Object();

		m_round = true;
		m_pickupable = true;
		
		switch (m_ore)
		{
			case ORE.GOLD:	
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Nugget Gold"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}	
			case ORE.COPPER:	
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Nugget Copper"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}
			case ORE.SILVER:	
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Nugget Silver"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}	
			case ORE.IRON:	
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Nugget Iron"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}	
			case ORE.NICKLE:	
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Nugget Nickle"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}	
			case ORE.PLATNUM:	
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Nugget Platnum"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}
			default:
			{
				m_game_object = GameObject.Instantiate(Resources.Load("Nugget Copper"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			}
		}
		
		m_pickup_sound = MINE_AUDIO.Instance.m_pickup_sound;
		
		m_fall_speed = 3.0f;
		m_roll_speed = 2.0f;

		Rotate_X(Random.Range(0,360));
		Rotate_Y(Random.Range(0,360));
		Rotate_Z(Random.Range(0,360));
	}
	
	public override void Process()
	{
		Process_For_Round_Falling_Objects(m_fall_speed, m_roll_speed);
	}
	
	public override void Process_Move()
	{
		Process_Move_For_Round_Falling_Objects();
	}
};

public class DIRT: OBJECT
{
	public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}
	
	public override bool Drill()
	{
		m_square.m_board.Remove_Object(this);

		m_square.Activate_All_Around_Square();
		
		return true;
	}

	public override bool Explode()
	{
		m_square.m_board.Remove_Object(this);

		m_square.Activate_All_Around_Square();
		
		return true;
	}

	public override void Initialize()
	{
		Initialize_Object();

		m_explodeable = true;
		m_drillable = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Dirt"), Vector3.zero, Quaternion.identity) as GameObject;
	}
	
	public override void Process()
	{
		// does not need to be processed because it
		// doesn't do anything by itself so deactivate
		m_square.m_active = false;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void Process_Move()
	{
		//  doesn't need to move
	}
};

public class DIRT_HARD: OBJECT
{
	public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}
	
	public override bool Drill()
	{
		DIRT dirt;
		dirt = new DIRT();
		dirt.Initialize();
		m_square.m_board.Place_Object(dirt, m_square);
		
		m_square.Activate_All_Around_Square();
		
		return true;
	}

	public override bool Explode()
	{
		DIRT dirt;
		dirt = new DIRT();
		dirt.Initialize();
		m_square.m_board.Place_Object(dirt, m_square);
		
		m_square.Activate_All_Around_Square();
		
		return true;
	}

	public override void Initialize()
	{
		Initialize_Object();

		m_explodeable = true;
		m_drillable = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Hard Dirt"), Vector3.zero, Quaternion.identity) as GameObject;
	}
	
	public override void Process()
	{
		// dirt does not need to be processed because they don't 
		// do anything by themselves so deactivate
		m_square.m_active = false;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void Process_Move()
	{
		// Dirt doesn't need to move
	}
};

public class TELEPORT: OBJECT
{
	static TELEPORT m_last_teleport = null;
	static TELEPORT m_first_teleport = null;
	SQUARE m_teleport_square;

	public override void SetSquare(SQUARE square)
	{
		// assigned my square
		m_square = square;
		
		// create a new square to carry teleport items
		m_teleport_square = new SQUARE();
		m_teleport_square.Initialize();
		m_teleport_square.m_board = m_square.m_board;
		
		// make the teleport square position the same
		m_teleport_square.m_row = m_square.m_row;
		m_teleport_square.m_column = m_square.m_column;
		
		// point all the teleport sqaures to just point to where the original square pointed so the space becomes pass thru
		m_teleport_square.m_left = m_square.m_left;
		m_teleport_square.m_right = m_square.m_right;
		m_teleport_square.m_above = m_square.m_above;
		m_teleport_square.m_below = m_square.m_below;
		
		// point all the the surrounding squares to the teleport square instead of original square
		m_square.m_left.m_right = m_teleport_square;
		m_square.m_right.m_left = m_teleport_square;
		m_square.m_above.m_below = m_teleport_square;
		m_square.m_below.m_above = m_teleport_square;
		
		// remember first teleport so we can always loop back to it, TODO this makes a copy of the whole class but we need a reference, need to find a solution
		if (m_first_teleport == null)
		{
			m_first_teleport = this;
		}
		
		if (m_last_teleport != null)
		{
			// point the first teleport exit squares at this teleport exit squares
			m_first_teleport.m_teleport_square.m_left = m_teleport_square.m_left;
			m_first_teleport.m_teleport_square.m_right = m_teleport_square.m_right;
			m_first_teleport.m_teleport_square.m_above = m_teleport_square.m_above;
			m_first_teleport.m_teleport_square.m_below = m_teleport_square.m_below;
			
			// move the position of the first teleport to this teleport
			m_first_teleport.m_teleport_square.m_row = m_teleport_square.m_row;
			m_first_teleport.m_teleport_square.m_column = m_teleport_square.m_column;

			// point all the the surrounding teleport exit squares to the last teleport exit squares
			m_teleport_square.m_right = m_last_teleport.m_square.m_right;
			m_teleport_square.m_left = m_last_teleport.m_square.m_left;
			m_teleport_square.m_below = m_last_teleport.m_square.m_below;
			m_teleport_square.m_above = m_last_teleport.m_square.m_above;
			
			// move the position of the teleport square to the last teleport position
			m_teleport_square.m_row = m_last_teleport.m_square.m_row;
			m_teleport_square.m_column = m_last_teleport.m_square.m_column;
		}
		
		m_last_teleport = this;
	}
	
	public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}
	
	public override void Initialize()
	{
		Initialize_Object();

		m_game_object = GameObject.Instantiate(Resources.Load("Cone"), Vector3.zero, Quaternion.identity) as GameObject;
		m_game_object.transform.Rotate (Vector3.forward, 90, Space.World);
		m_game_object.transform.Rotate (Vector3.down, 90, Space.World);
	}
	
	public override void Process()
	{
		m_teleport_square.Activate_All_Around_Square();
		m_teleport_square.m_active = true;

		// does not need to be processed because they don't 
		// do anything by themselves so deactivate
		m_square.m_active = true;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void Process_Move()
	{
		// doesn't need to move
	}
};

public class CONVEYOR_BELT: OBJECT
{
	SQUARE m_conveyor_belt_square;
	DIRECTION m_direction;
	
	public CONVEYOR_BELT(DIRECTION direction)
	{
		m_direction = direction;
	}
	
	private CONVEYOR_BELT()
	{
		m_direction = DIRECTION.NONE;
	}
	
	public override bool Toggle (OBJECT_COLOR color)
	{
		// allow conveyor belts to be turned on and off
		return false;
	}
	
	public override void SetSquare(SQUARE square)
	{
		// assigned my square
		m_square = square;
		
		// create a new square to carry items
		m_conveyor_belt_square = new SQUARE();
		m_conveyor_belt_square.Initialize();
		m_conveyor_belt_square.m_board = m_square.m_board;
		
		// make the conveyor belt square position the same
		m_conveyor_belt_square.m_row = m_square.m_row;
		m_conveyor_belt_square.m_column = m_square.m_column;
		
		// point all the conveyor belt sqaures to just point to where the original square pointed so the space becomes pass thru
		m_conveyor_belt_square.m_left = m_square.m_left;
		m_conveyor_belt_square.m_right = m_square.m_right;
		m_conveyor_belt_square.m_above = m_square.m_above;
		m_conveyor_belt_square.m_below = m_square.m_below;
		
		// point all the the surrounding squares to the conveyor belt square instead of original square (TODO: teleporters are not handled right here)
		m_square.m_left.m_right = m_conveyor_belt_square;
		m_square.m_right.m_left = m_conveyor_belt_square;
		m_square.m_above.m_below = m_conveyor_belt_square;
		m_square.m_below.m_above = m_conveyor_belt_square;
		
		// mark that this is a conveyor belt
		m_conveyor_belt_square.m_conveyor_belt = true;
		m_conveyor_belt_square.m_conveyor_belt_direction = m_direction;
		m_conveyor_belt_square.m_conveyor_belt_speed = 5.0f;
	}
	
	public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}
	
	public override void Initialize()
	{
		Initialize_Object();
		
		m_game_object = GameObject.Instantiate(Resources.Load("Conveyor"), Vector3.zero, Quaternion.identity) as GameObject;
		m_game_object.transform.Rotate (Vector3.left, 90, Space.World);
		m_game_object.transform.Rotate (Vector3.forward, 90, Space.World);
		m_game_object.transform.Rotate (Vector3.down, 90, Space.World);
		
		switch(m_direction)
		{
			case DIRECTION.UP:
				m_game_object.transform.Rotate (Vector3.forward, 90, Space.World);
				break;
			case DIRECTION.LEFT:
				m_game_object.transform.Rotate (Vector3.forward, 180, Space.World);
				break;
			case DIRECTION.DOWN:
				m_game_object.transform.Rotate (Vector3.forward, 270, Space.World);
				break;
			case DIRECTION.RIGHT:
			case DIRECTION.NONE:
				break;
				
		}
	}
	
	public override void Process()
	{
		// square doesn't do anything
		m_square.m_active = true;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
		m_new_square = m_square;
	}
	
	public override void Process_Move()
	{
		float scrollSpeed = 0.5f * m_conveyor_belt_square.m_conveyor_belt_speed;
		
		float offset = Time.time * scrollSpeed % 1.0f;
		
		m_game_object.GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", new Vector2(-offset, 0));
		m_game_object.GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_BumpMap", new Vector2(-offset, 0));
		// doesn't need to move
	}
};


public class ENTRANCE: OBJECT
{
	public SQUARE m_entrance_square;
	
	public override void SetSquare(SQUARE square)
	{
		// assigned my square
		m_square = square;
		
		// create a new square to carry items
		m_entrance_square = new SQUARE();
		m_entrance_square.Initialize();
		m_entrance_square.m_board = m_square.m_board;
		
		// make the square position the same
		m_entrance_square.m_row = m_square.m_row;
		m_entrance_square.m_column = m_square.m_column;
		
		// point all the squares to just point to where the original square pointed
		m_entrance_square.m_left = m_square.m_left;
		m_entrance_square.m_right = m_square.m_right;
		m_entrance_square.m_above = m_square.m_above;
		m_entrance_square.m_below = m_square.m_below;
		
		// mark entrance
		m_entrance_square.m_entrance = true;
		m_square.m_entrance = true;
		
		m_square.m_board.m_entrance_square = m_entrance_square;
	}
	
	public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}
	
	public override void Initialize()
	{
		Initialize_Object();

		m_round = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Entrance"), Vector3.zero, Quaternion.identity) as GameObject;
		m_game_object.transform.Rotate (Vector3.forward, 90, Space.World);
		m_game_object.transform.Rotate (Vector3.down, 90, Space.World);
	}
	
	public override void Process()
	{
		// square doesn't do anything
		m_square.m_active = false;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void Process_Move()
	{		
		// doesn't need to move
	}
};

public class EXIT: OBJECT
{
	public SQUARE m_exit_square;
	public bool m_open;
	
	public override void SetSquare(SQUARE square)
	{
		// assigned my square
		m_square = square;
		
		// create a new square to carry items
		m_exit_square = new SQUARE();
		m_exit_square.Initialize();
		m_exit_square.m_board = m_square.m_board;
		
		// make the square position the same
		m_exit_square.m_row = m_square.m_row;
		m_exit_square.m_column = m_square.m_column;
		
		// exit square leads no where
		m_exit_square.m_right = m_exit_square;
		m_exit_square.m_left = m_exit_square;
		m_exit_square.m_below = m_exit_square;
		m_exit_square.m_above = m_exit_square;
		
		// mark exit
		m_exit_square.m_exit = true;
		m_square.m_exit = true;
	}
	
	public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}
	
	public override void Initialize()
	{
		Initialize_Object();

		m_round = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Exit"), Vector3.zero, Quaternion.identity) as GameObject;
		m_game_object.transform.Rotate (Vector3.forward, 90, Space.World);
		m_game_object.transform.Rotate (Vector3.down, 90, Space.World);
	}
	
	public override void Process()
	{
		// open the exit
		if ((m_open == false) && (SCORE.m_score_point_this_level >= m_square.m_board.m_quota))
		{
			// point all the squares to just point to where the original square pointed
			m_square.m_left.m_right = m_exit_square;
			m_square.m_right.m_left = m_exit_square;
			m_square.m_above.m_below = m_exit_square;
			m_square.m_below.m_above = m_exit_square;
			m_open = true;
			m_square.Activate_All_Around_Square();
		}
		
		if (m_open == true)
		{
			// something in the exit?
			if ((m_exit_square.Occupied() == true) && (m_exit_square.m_object.m_new_square != m_exit_square))
			{
				if (m_exit_square.m_object is PLAYER)
				{
					if (m_square.m_board.m_player_exit == false)
					{
						m_square.m_board.m_player_exit = true;
						m_square.m_board.m_player_exit_time = Time.time;
					}
				}
				else
				{
					m_square.m_board.Remove_Object(m_exit_square.m_object);
				}
			}
		}
		m_square.m_active = true;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void Process_Move()
	{	
		// doesn't need to move
	}
}; 

public class DOOR: OBJECT
{
	public SQUARE m_door_square;
	AudioClip m_door_sound;
	
	public bool m_open;
	OBJECT_COLOR  m_color;
	
	public DOOR(OBJECT_COLOR color)
	{
		m_color = color;
		m_open = false;
	}
	
	public override void SetSquare(SQUARE square)
	{
		// assigned my square
		m_square = square;
		
		// create a new square to carry items
		m_door_square = new SQUARE();
		m_door_square.Initialize();
		m_door_square.m_board = m_square.m_board;
		
		// make the square position the same
		m_door_square.m_row = m_square.m_row;
		m_door_square.m_column = m_square.m_column;
		
		// point all the squares to just point to where the original square pointed
//		m_square.m_left.m_right = m_square;
//		m_square.m_right.m_left = m_square;
//		m_square.m_above.m_below = m_square;
//		m_square.m_below.m_above = m_square;	
		
		m_door_square.m_right = m_square.m_right;
		m_door_square.m_left = m_square.m_left;
		m_door_square.m_below = m_square.m_below;
		m_door_square.m_above = m_square.m_above;
		
		m_open = false;
	}
	
	public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}
	
	public override bool Open()
	{
		switch (m_color)
		{
			case OBJECT_COLOR.GREEN:
				if ((SCORE.m_number_of_green_keys > 0) && (m_open == false))
				{
					SCORE.m_number_of_green_keys--;
					Toggle(m_color);
					return true;
				}
				break;
			case OBJECT_COLOR.YELLOW:
				if ((SCORE.m_number_of_yellow_keys > 0) && (m_open == false))
				{
					SCORE.m_number_of_yellow_keys--;
					Toggle(m_color);
					return true;
				}
				break;
			case OBJECT_COLOR.BLUE:
				if ((SCORE.m_number_of_blue_keys > 0) && (m_open == false))
				{
					SCORE.m_number_of_blue_keys--;
					Toggle(m_color);
					return true;
				}
				break;
			case OBJECT_COLOR.RED:
				if ((SCORE.m_number_of_red_keys > 0) && (m_open == false))
				{
					SCORE.m_number_of_red_keys--;
					Toggle(m_color);
					return true;
				}
				break;
		}
		
		return false;
	}

	public override bool Toggle(OBJECT_COLOR color)
	{
		// TODO need a waiting to go up or down so object can reside on the door until they are free to move
		if (color == m_color)
		{
			if (m_open == true)
			{
				if (m_door_square.Occupied() == false)
				{
					m_square.m_left.m_right = m_square;
					m_square.m_right.m_left = m_square;
					m_square.m_above.m_below = m_square;
					m_square.m_below.m_above = m_square;	

					m_open = false;
					m_game_object.GetComponent<Animation>().Play("up");
					m_game_object.GetComponent<AudioSource>().PlayOneShot(m_door_sound);
					m_game_object.transform.FindChild("Circle").gameObject.GetComponent<Renderer>().material.SetColor ("_Emission", Color.black);
				}
			}
			else
			{
				m_square.m_left.m_right = m_door_square;
				m_square.m_right.m_left = m_door_square;
				m_square.m_above.m_below = m_door_square;
				m_square.m_below.m_above = m_door_square;
				
				m_open = true;
				m_game_object.GetComponent<Animation>().Play("down");
				m_game_object.GetComponent<AudioSource>().PlayOneShot(m_door_sound);
				m_game_object.transform.FindChild("Circle").gameObject.GetComponent<Renderer>().material.SetColor ("_Emission", m_game_object.transform.FindChild("Circle").gameObject.GetComponent<Renderer>().material.GetColor("_Color"));
			}
			
			m_square.Activate_All_Around_Square();
			return true;
		}
		
		return false;
	}
	
	public override void Initialize()
	{
		Initialize_Object();
		
		m_openable = true;
		
		switch (m_color)
		{
			case OBJECT_COLOR.BLUE:
			m_game_object = GameObject.Instantiate(Resources.Load("Door Blue"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
				
			case OBJECT_COLOR.GREEN:
			m_game_object = GameObject.Instantiate(Resources.Load("Door Green"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
				
			case OBJECT_COLOR.YELLOW:
			m_game_object = GameObject.Instantiate(Resources.Load("Door Yellow"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
			
			case OBJECT_COLOR.RED:
			default:
			m_game_object = GameObject.Instantiate(Resources.Load("Door Red"), Vector3.zero, Quaternion.identity) as GameObject;
				break;
		}
		m_game_object.transform.Rotate (Vector3.forward, 90, Space.World);
		m_game_object.transform.Rotate (Vector3.down, 90, Space.World);
		
		m_door_sound = MINE_AUDIO.Instance.m_door_sound;
	}
	
	public override void Process()
	{		
		m_square.m_active = true;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void Process_Move()
	{		
		// doesn't need to move
	}
}; 

public class SWITCH_MOMENTARY: OBJECT
{
	public SQUARE m_switch_square;
	
	bool m_open;
	OBJECT_COLOR  m_color;
	
	public SWITCH_MOMENTARY(OBJECT_COLOR color)
	{
		m_color = color;
		m_open = false;
	}
	
	public override void SetSquare(SQUARE square)
	{
		// assigned my square
		m_square = square;
		
		// create a new square to carry items
		m_switch_square = new SQUARE();
		m_switch_square.Initialize();
		m_switch_square.m_board = m_square.m_board;
		
		// make the square position the same
		m_switch_square.m_row = m_square.m_row;
		m_switch_square.m_column = m_square.m_column;
		
		// point all the squares to just point to where the original square pointed
		m_square.m_left.m_right = m_switch_square;
		m_square.m_right.m_left = m_switch_square;
		m_square.m_above.m_below = m_switch_square;
		m_square.m_below.m_above = m_switch_square;	
		
		m_switch_square.m_right = m_square.m_right;
		m_switch_square.m_left = m_square.m_left;
		m_switch_square.m_below = m_square.m_below;
		m_switch_square.m_above = m_square.m_above;
	}
	
	public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}
		
	public override void Initialize()
	{
		Initialize_Object();

		m_round = true;
		
		switch (m_color)
		{
			case OBJECT_COLOR.BLUE:
		m_game_object = GameObject.Instantiate(Resources.Load("Button Blue"), Vector3.zero, Quaternion.identity) as GameObject;
			break;
			case OBJECT_COLOR.RED:
		m_game_object = GameObject.Instantiate(Resources.Load("Button Red"), Vector3.zero, Quaternion.identity) as GameObject;
			break;
			case OBJECT_COLOR.YELLOW:
		m_game_object = GameObject.Instantiate(Resources.Load("Button Yellow"), Vector3.zero, Quaternion.identity) as GameObject;
			break;
			case OBJECT_COLOR.GREEN:
			default:
		m_game_object = GameObject.Instantiate(Resources.Load("Button Green"), Vector3.zero, Quaternion.identity) as GameObject;
			break;
		}
		
		m_game_object.transform.Rotate (Vector3.forward, 90, Space.World);
		m_game_object.transform.Rotate (Vector3.down, 90, Space.World);
	}
	
	public override void Process()
	{
		// square doesn't do anything
		if ((m_switch_square.Occupied() == true) && (m_open == false))
		{
			m_game_object.transform.FindChild("Sphere").gameObject.GetComponent<Renderer>().material.SetColor ("_Emission", m_game_object.transform.FindChild("Sphere").gameObject.GetComponent<Renderer>().material.GetColor("_Color"));
			// Toggle all items that are togglable.
			m_square.m_board.Toggle_Objects(m_color);
			m_open = true;
		}
		else if ((m_switch_square.Occupied() == false) && (m_open == true))
		{
			m_game_object.transform.FindChild("Sphere").gameObject.GetComponent<Renderer>().material.SetColor ("_Emission", Color.black);
			// Toggle all items that are togglable.
			m_square.m_board.Toggle_Objects(m_color);
			m_open = false;
		}
		
		m_square.m_active = true;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void Process_Move()
	{		
		// doesn't need to move
	}
}; 

public class SWITCH_TOGGLE: OBJECT
{
	public SQUARE m_switch_square;
	
	bool m_open;
	OBJECT_COLOR m_color;
	bool m_light;
	
	public SWITCH_TOGGLE(OBJECT_COLOR color)
	{
		m_color = color;
		m_open = false;
		m_light= false;
	}
	
	public override void SetSquare(SQUARE square)
	{
		// assigned my square
		m_square = square;
		
		// create a new square to carry items
		m_switch_square = new SQUARE();
		m_switch_square.Initialize();
		m_switch_square.m_board = m_square.m_board;
		
		// make the square position the same
		m_switch_square.m_row = m_square.m_row;
		m_switch_square.m_column = m_square.m_column;
		
		// point all the squares to just point to where the original square pointed
		m_square.m_left.m_right = m_switch_square;
		m_square.m_right.m_left = m_switch_square;
		m_square.m_above.m_below = m_switch_square;
		m_square.m_below.m_above = m_switch_square;	
		
		m_switch_square.m_right = m_square.m_right;
		m_switch_square.m_left = m_square.m_left;
		m_switch_square.m_below = m_square.m_below;
		m_switch_square.m_above = m_square.m_above;
	}
	
	public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		return false;
	}
		
	public override void Initialize()
	{
		Initialize_Object();

		m_round = true;
		
		switch (m_color)
		{
			case OBJECT_COLOR.RED:
			m_game_object = GameObject.Instantiate(Resources.Load("Button Red"), Vector3.zero, Quaternion.identity) as GameObject;
			break;
			case OBJECT_COLOR.GREEN:
			m_game_object = GameObject.Instantiate(Resources.Load("Button Green"), Vector3.zero, Quaternion.identity) as GameObject;
			break;
			case OBJECT_COLOR.BLUE:
			m_game_object = GameObject.Instantiate(Resources.Load("Button Blue"), Vector3.zero, Quaternion.identity) as GameObject;
			break;
			case OBJECT_COLOR.YELLOW:
			default:
			m_game_object = GameObject.Instantiate(Resources.Load("Button Yellow"), Vector3.zero, Quaternion.identity) as GameObject;
			break;
		}

		m_game_object.transform.Rotate (Vector3.forward, 90, Space.World);
		m_game_object.transform.Rotate (Vector3.down, 90, Space.World);
	}
	
	public override void Process()
	{
		// square doesn't do anything
		if ((m_switch_square.Occupied() == false) && (m_open == false))
		{
			m_open = true;
		}
		else if ((m_switch_square.Occupied() == true) && (m_open == true))
		{
			// Toggle all items that are togglable.
			m_square.m_board.Toggle_Objects(m_color);
			m_open = false;
			
			if (m_light == true)
			{
				m_game_object.transform.FindChild("Sphere").gameObject.GetComponent<Renderer>().material.SetColor ("_Emission", Color.black);
				m_light = false;
			}
			else
			{
				m_game_object.transform.FindChild("Sphere").gameObject.GetComponent<Renderer>().material.SetColor ("_Emission", m_game_object.transform.FindChild("Sphere").gameObject.GetComponent<Renderer>().material.GetColor("_Color"));
				m_light = true;
			}
		}
		m_square.m_active = true;
		m_horizontal_velocity = 0;
		m_verticle_velocity = 0;
	}
	
	public override void Process_Move()
	{		
		// doesn't need to move
	}
}; 

public class ROCK_MONSTER: OBJECT
{
	float m_speed;
	DIRECTION m_direction;
	AudioClip m_eat_sound;
	AudioClip m_crush_sound;
	
	public override void Set_Position(float x, float y, float z)
	{
		m_game_object.transform.Translate(x - m_game_object.transform.position.x, 
				y - m_game_object.transform.position.y, 
				z - m_game_object.transform.position.z, Space.World);
		
		//m_face_object.transform.position = m_game_object.transform.position;
	}

	public override void Offset_Position(Vector3 start_position, Vector3 target_position, float transition)
	{
		m_game_object.transform.position = Vector3.Lerp(start_position, target_position, transition);
		//m_face_object.transform.position = Vector3.Lerp(start_position, target_position, transition);
	}

	public override bool Push(float push_object_speed, DIRECTION direction, bool rolling)
	{
		// Monsters cannot be pushed
		return false;
	}
	
	public override bool Drill()
	{
		m_square.Splat_Crystals();
		
		m_square.Activate_All_Around_Square();
		
		return true;
	}

	public override bool Crush()
	{
		Vector3 save_position = m_game_object.transform.position;;
		
		m_square.Splat_Crystals();
		
		AudioSource.PlayClipAtPoint(m_crush_sound, save_position);

		return true;
	}
	
	public override bool Explode()
	{
		m_square.Splat_Crystals();
			
		m_square.Activate_All_Around_Square();

		return true;
	}
	
	public override void Initialize()
	{
		Initialize_Object();
		
		m_direction = DIRECTION.RIGHT;
		
		m_round = true;
		m_crushable = true;
		m_rolling = true;
		m_explodeable = true;
		m_drillable = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Rock Monster"), Vector3.zero, Quaternion.identity) as GameObject;
		m_eat_sound = MINE_AUDIO.Instance.m_eat_sound;
		m_crush_sound = MINE_AUDIO.Instance.m_crush_sound;
		m_moving_sound = MINE_AUDIO.Instance.m_moving_sound;
		
		m_speed = 5.0f;
	}
	
	public void Process_New_Right()
	{
		SQUARE right_square;
		SQUARE forward_square;
		SQUARE right_forward_square;
		SQUARE right_behind_square;
		SQUARE left_square;
		SQUARE behind_square;
		OBJECT right_object;
		OBJECT forward_object;
		OBJECT right_forward_object;
		OBJECT right_behind_object;
		OBJECT left_object;
		OBJECT behind_object;
		DIRECTION right_direction;
		DIRECTION forward_direction;
		DIRECTION left_direction;
		DIRECTION behind_direction;

		right_square = m_square.Get_Square_Right(m_direction);
		forward_square = m_square.Get_Square_Forward(m_direction);
		left_square = m_square.Get_Square_Left(m_direction);
		behind_square = m_square.Get_Square_Behind(m_direction);
		right_forward_square = right_square.Get_Square_Forward(m_direction);
		right_behind_square = right_square.Get_Square_Behind(m_direction);

		right_object = right_square.m_object;
		forward_object = forward_square.m_object;
		right_forward_object = right_forward_square.m_object;
		right_behind_object = right_behind_square.m_object;
		left_object = left_square.m_object;
		behind_object = behind_square.m_object;

		right_direction = m_square.Get_Direction_Right(m_direction);
		forward_direction = m_square.Get_Direction_Front(m_direction);
		left_direction = m_square.Get_Direction_Left(m_direction);
		behind_direction = m_square.Get_Direction_Behind(m_direction);

/*
		// Eat the object in front of us and move there if eatable
		if ((forward_object != null) && (forward_object.m_eatable == true))
		{
			m_game_object.audio.PlayOneShot(eat_sound);
			forward_object.Eat();
			m_square.m_board.Start_Move_Object(this, forward_square, forward_direction, m_speed, true);
			m_direction = forward_direction;
		}
		// Eat the object to the right of us and move there if eatable
		else if ((right_object != null) && (right_object.m_eatable == true))
		{
			m_game_object.audio.PlayOneShot(eat_sound);
			right_object.Eat();
			m_square.m_board.Start_Move_Object(this, right_square, right_direction, m_speed, true);
			m_direction = right_direction;
		}

		// Eat the object to the left of us and move there if eatable
		else if ((left_object != null) && (left_object.m_eatable == true))
		{
			m_game_object.audio.PlayOneShot(eat_sound);
			left_object.Eat();
			m_square.m_board.Start_Move_Object(this, left_square, left_direction, m_speed, true);
			m_direction = left_direction;
		}
		// Eat the object behind us and move there if eatable
		else if ((behind_object != null) && (behind_object.m_eatable == true))
		{
			m_game_object.audio.PlayOneShot(eat_sound);
			behind_object.Eat();
			m_square.m_board.Start_Move_Object(this, behind_square, behind_direction, m_speed, true);
			m_direction = behind_direction;
		}
*/
		// move to the left third if space is available
		if ((right_forward_object != null) && (forward_object == null))
		{
			m_square.m_board.Start_Move_Object(this, forward_square, forward_direction, m_speed, true);
			m_direction = forward_direction;
		}
		else if ((right_object != null) && (forward_object == null))
		{
			m_square.m_board.Start_Move_Object(this, forward_square, forward_direction, m_speed, true);
			m_direction = forward_direction;
		}
		else if ((right_behind_object != null) && (right_object == null))
		{
			m_square.m_board.Start_Move_Object(this, right_square, right_direction, m_speed, true);
			m_direction = right_direction;
		}
		
		// move to the forward second if space is available
		else if (forward_object == null)
		{
			m_square.m_board.Start_Move_Object(this, forward_square, forward_direction, m_speed, true);
			m_direction = forward_direction;
		}
		// move to the right first if space is available
		else if (right_object == null)
		{
			m_square.m_board.Start_Move_Object(this, right_square, right_direction, m_speed, true);
			m_direction = right_direction;
		}
		// move to the left third if space is available
		else if (left_object == null)
		{
			m_square.m_board.Start_Move_Object(this, left_square, left_direction, m_speed, true);
			m_direction = left_direction;
		}
		// move behind forth if space is available
		else if (behind_object == null)
		{
			m_square.m_board.Start_Move_Object(this, behind_square, behind_direction, m_speed, true);
			m_direction = behind_direction;
		}
		// we cannot move
		else
		{
			m_square.m_active = true;
			m_horizontal_velocity = 0;	
			m_verticle_velocity = 0;
			
			// force a call to update and spin the monster in place, normally does not get called in this situation so monster stops moving
			Process_Move();
		}
	}
	
	public override void Process()
	{
		Process_Right();
	}
	
	public void Process_Right()
	{
		// Eat the object if the object is the right turn path of the monster we will move there below
		if ((m_square.m_below.Occupied() == true) && 
			(m_square.m_below.m_object.m_eatable) && 
			(m_direction == DIRECTION.RIGHT))
		{
			this.m_game_object.GetComponent<AudioSource>().PlayOneShot(m_eat_sound);
			m_square.m_below.m_object.Eat(this);
		}
		else if ((m_square.m_above.Occupied() == true) && 
			(m_square.m_above.m_object.m_eatable) && 
			(m_direction == DIRECTION.LEFT))
		{
			this.m_game_object.GetComponent<AudioSource>().PlayOneShot(m_eat_sound);
			m_square.m_above.m_object.Eat(this);
		}
		else if ((m_square.m_right.Occupied() == true) && 
			(m_square.m_right.m_object.m_eatable) && 
			(m_direction == DIRECTION.UP))
		{
			this.m_game_object.GetComponent<AudioSource>().PlayOneShot(m_eat_sound);
			m_square.m_right.m_object.Eat(this);
		}
		else if ((m_square.m_left.Occupied() == true) && 
			(m_square.m_left.m_object.m_eatable) && 
			(m_direction == DIRECTION.DOWN))
		{
			this.m_game_object.GetComponent<AudioSource>().PlayOneShot(m_eat_sound);
			m_square.m_left.m_object.Eat(this);
		}			
		
		// Eat the object if the object is in front of the monster and the monster is moving in that direction and then move there instead of any other move
		SQUARE square;
		square = m_square.Get_Square_Forward(m_direction);
		if ((square.Occupied() == true) && (square.m_object.m_eatable))
		{
			this.m_game_object.GetComponent<AudioSource>().PlayOneShot(m_eat_sound);
			square.m_object.Eat(this);
			m_square.m_board.Start_Move_Object(this, square, m_direction, m_speed, true);
		}
		
		// continue moving the monster up if there still is an object to the right of the monster
		else if ((m_square.m_right.Occupied() == true) &&
			(m_square.m_above.Occupied() == false) &&
			(m_direction == DIRECTION.UP))
		{
			m_direction = DIRECTION.UP;
			m_square.m_board.Start_Move_Object(this, m_square.m_above, m_direction, m_speed, true);
		}
		else if ((m_square.m_right.m_below.Occupied() == true) &&
			(m_square.m_right.Occupied() == false) &&
			(m_direction == DIRECTION.UP))
		{
			m_direction = DIRECTION.RIGHT;
			m_square.m_board.Start_Move_Object(this, m_square.m_right, m_direction, m_speed, true);
		}
		
		// continue moving the monster to the right if there still is an object below the monster
		else if ((m_square.m_below.Occupied() == true) && 
			(m_square.m_right.Occupied() == false) &&
			(m_direction == DIRECTION.RIGHT))
		{
			m_direction = DIRECTION.RIGHT;
			m_square.m_board.Start_Move_Object(this, m_square.m_right, m_direction, m_speed, true);
		}
		else if ((m_square.m_below.m_left.Occupied() == true) &&
			(m_square.m_below.Occupied() == false) &&
			(m_direction == DIRECTION.RIGHT))
		{
			m_direction = DIRECTION.DOWN;
			m_square.m_board.Start_Move_Object(this, m_square.m_below, m_direction, m_speed, true);
		}
		else if ((m_square.m_left.Occupied() == true) &&
			(m_square.m_below.Occupied() == false) &&
			(m_direction == DIRECTION.DOWN))
		{
			m_direction = DIRECTION.DOWN;
			m_square.m_board.Start_Move_Object(this, m_square.m_below, m_direction, m_speed, true);
		}
		else if ((m_square.m_left.m_above.Occupied() == true) &&
			(m_square.m_left.Occupied() == false) &&
			(m_direction == DIRECTION.DOWN))
		{
			m_direction = DIRECTION.LEFT;
			m_square.m_board.Start_Move_Object(this, m_square.m_left, m_direction, m_speed, true);
		}
		else if ((m_square.m_above.Occupied() == true) &&
			(m_square.m_left.Occupied() == false) &&
			(m_direction == DIRECTION.LEFT))
		{
			m_direction = DIRECTION.LEFT;
			m_square.m_board.Start_Move_Object(this, m_square.m_left, m_direction, m_speed, true);
		}
		else if ((m_square.m_above.m_right.Occupied() == true) &&
			(m_square.m_above.Occupied() == false) &&
			(m_direction == DIRECTION.LEFT))
		{
			m_direction = DIRECTION.UP;
			m_square.m_board.Start_Move_Object(this, m_square.m_above, m_direction, m_speed, true);
		}
		else if ((m_square.m_above.Occupied() == true) &&
			(m_square.m_right.Occupied() == true) &&
			(m_square.m_left.Occupied() == false) &&
			(m_direction == DIRECTION.UP))
		{
			m_direction = DIRECTION.LEFT;
			m_square.m_board.Start_Move_Object(this, m_square.m_left, m_direction, m_speed, true);
		}
		else if ((m_square.m_below.Occupied() == true) &&
			(m_square.m_left.Occupied() == true) &&
			(m_square.m_right.Occupied() == false) &&
			(m_direction == DIRECTION.DOWN))
		{
			m_direction = DIRECTION.RIGHT;
			m_square.m_board.Start_Move_Object(this, m_square.m_right, m_direction, m_speed, true);
		}
		else if ((m_square.m_right.Occupied() == true) &&
			(m_square.m_below.Occupied() == true) &&
			(m_square.m_above.Occupied() == false) &&
			(m_direction == DIRECTION.RIGHT))
		{
			m_direction = DIRECTION.UP;
			m_square.m_board.Start_Move_Object(this, m_square.m_above, m_direction, m_speed, true);
		}
		else if ((m_square.m_left.Occupied() == true) &&
			(m_square.m_above.Occupied() == true) &&
			(m_square.m_below.Occupied() == false) &&
			(m_direction == DIRECTION.LEFT))
		{
			m_direction = DIRECTION.DOWN;
			m_square.m_board.Start_Move_Object(this, m_square.m_below, m_direction, m_speed, true);
		}
		
		// start things out to the left
		else if (m_square.m_left.Occupied() == false)
		{
			m_direction = DIRECTION.LEFT;
			m_square.m_board.Start_Move_Object(this, m_square.m_left, m_direction, m_speed, true);
		}
		else if (m_square.m_above.Occupied() == false)
		{
			m_direction = DIRECTION.UP;
			m_square.m_board.Start_Move_Object(this, m_square.m_above, m_direction, m_speed, true);
		}
		else if (m_square.m_right.Occupied() == false)
		{
			m_direction = DIRECTION.RIGHT;
			m_square.m_board.Start_Move_Object(this, m_square.m_right, m_direction, m_speed, true);
		}
		else if (m_square.m_below.Occupied() == false)
		{
			m_direction = DIRECTION.DOWN;
			m_square.m_board.Start_Move_Object(this, m_square.m_below, m_direction, m_speed, true);
		}
		
		// we cannot move so deactivate
		else
		{
			m_square.m_active = true;
			m_horizontal_velocity = 0;	
			m_verticle_velocity = 0;
			
			// force a call to update and spin the monster in place, normally does not get called in this situation so monster stops moving
			Process_Move();
		}
	}
	
	public void Process_Left()
	{
		// Eat the object if the object is the left turn path of the monster we will move there below
		if ((m_square.m_above.Occupied() == true) && 
			(m_square.m_above.m_object.m_eatable) && 
			(m_direction == DIRECTION.RIGHT))
		{
			m_square.m_below.m_object.Eat(this);
		}
		else if ((m_square.m_below.Occupied() == true) && 
			(m_square.m_below.m_object.m_eatable) && 
			(m_direction == DIRECTION.LEFT))
		{
			m_square.m_above.m_object.Eat(this);
		}
		else if ((m_square.m_left.Occupied() == true) && 
			(m_square.m_left.m_object.m_eatable) && 
			(m_direction == DIRECTION.UP))
		{
			m_square.m_right.m_object.Eat(this);
		}
		else if ((m_square.m_right.Occupied() == true) && 
			(m_square.m_right.m_object.m_eatable) && 
			(m_direction == DIRECTION.DOWN))
		{
			m_square.m_left.m_object.Eat(this);
		}			
		
		// Eat the object if the object is in front of the monster and the monster is moving in that direction and then move there instead of any other move
		SQUARE square;
		square = m_square.Get_Square_Forward(m_direction);
		if ((square.Occupied() == true) && (square.m_object.m_eatable))
		{
			square.m_object.Eat(this);
			m_square.m_board.Start_Move_Object(this, square, m_direction, m_speed, true);
		}
		
		// continue moving the monster down if there still is an object to the left of the monster
		else if ((m_square.m_left.Occupied() == true) &&
			(m_square.m_below.Occupied() == false) &&
			(m_direction == DIRECTION.DOWN))
		{
			m_direction = DIRECTION.DOWN;
			m_square.m_board.Start_Move_Object(this, m_square.m_below, m_direction, m_speed, true);
		}
		else if ((m_square.m_left.m_above.Occupied() == true) &&
			(m_square.m_left.Occupied() == false) &&
			(m_direction == DIRECTION.DOWN))
		{
			m_direction = DIRECTION.LEFT;
			m_square.m_board.Start_Move_Object(this, m_square.m_left, m_direction, m_speed, true);
		}
		
		// continue moving the monster to the right if there still is an object below the monster
		else if ((m_square.m_above.Occupied() == true) && 
			(m_square.m_left.Occupied() == false) &&
			(m_direction == DIRECTION.LEFT))
		{
			m_direction = DIRECTION.LEFT;
			m_square.m_board.Start_Move_Object(this, m_square.m_left, m_direction, m_speed, true);
		}
		else if ((m_square.m_above.m_right.Occupied() == true) &&
			(m_square.m_above.Occupied() == false) &&
			(m_direction == DIRECTION.LEFT))
		{
			m_direction = DIRECTION.UP;
			m_square.m_board.Start_Move_Object(this, m_square.m_above, m_direction, m_speed, true);
		}
		else if ((m_square.m_right.Occupied() == true) &&
			(m_square.m_above.Occupied() == false) &&
			(m_direction == DIRECTION.UP))
		{
			m_direction = DIRECTION.UP;
			m_square.m_board.Start_Move_Object(this, m_square.m_above, m_direction, m_speed, true);
		}
		else if ((m_square.m_right.m_below.Occupied() == true) &&
			(m_square.m_right.Occupied() == false) &&
			(m_direction == DIRECTION.UP))
		{
			m_direction = DIRECTION.RIGHT;
			m_square.m_board.Start_Move_Object(this, m_square.m_right, m_direction, m_speed, true);
		}
		else if ((m_square.m_below.Occupied() == true) &&
			(m_square.m_right.Occupied() == false) &&
			(m_direction == DIRECTION.RIGHT))
		{
			m_direction = DIRECTION.RIGHT;
			m_square.m_board.Start_Move_Object(this, m_square.m_right, m_direction, m_speed, true);
		}
		else if ((m_square.m_below.m_left.Occupied() == true) &&
			(m_square.m_below.Occupied() == false) &&
			(m_direction == DIRECTION.RIGHT))
		{
			m_direction = DIRECTION.DOWN;
			m_square.m_board.Start_Move_Object(this, m_square.m_below, m_direction, m_speed, true);
		}
		else if ((m_square.m_below.Occupied() == true) &&
			(m_square.m_left.Occupied() == true) &&
			(m_square.m_right.Occupied() == false) &&
			(m_direction == DIRECTION.DOWN))
		{
			m_direction = DIRECTION.RIGHT;
			m_square.m_board.Start_Move_Object(this, m_square.m_right, m_direction, m_speed, true);
		}
		else if ((m_square.m_above.Occupied() == true) &&
			(m_square.m_right.Occupied() == true) &&
			(m_square.m_left.Occupied() == false) &&
			(m_direction == DIRECTION.UP))
		{
			m_direction = DIRECTION.LEFT;
			m_square.m_board.Start_Move_Object(this, m_square.m_left, m_direction, m_speed, true);
		}
		else if ((m_square.m_left.Occupied() == true) &&
			(m_square.m_above.Occupied() == true) &&
			(m_square.m_below.Occupied() == false) &&
			(m_direction == DIRECTION.LEFT))
		{
			m_direction = DIRECTION.DOWN;
			m_square.m_board.Start_Move_Object(this, m_square.m_below, m_direction, m_speed, true);
		}
		else if ((m_square.m_right.Occupied() == true) &&
			(m_square.m_below.Occupied() == true) &&
			(m_square.m_above.Occupied() == false) &&
			(m_direction == DIRECTION.RIGHT))
		{
			m_direction = DIRECTION.UP;
			m_square.m_board.Start_Move_Object(this, m_square.m_above, m_direction, m_speed, true);
		}

		// start things out to the right
		else if (m_square.m_right.Occupied() == false)
		{
			m_direction = DIRECTION.RIGHT;
			m_square.m_board.Start_Move_Object(this, m_square.m_right, m_direction, m_speed, true);
		}
		else if (m_square.m_below.Occupied() == false)
		{
			m_direction = DIRECTION.DOWN;
			m_square.m_board.Start_Move_Object(this, m_square.m_below, m_direction, m_speed, true);
		}
		else if (m_square.m_left.Occupied() == false)
		{
			m_direction = DIRECTION.LEFT;
			m_square.m_board.Start_Move_Object(this, m_square.m_left, m_direction, m_speed, true);
		}
		else if (m_square.m_above.Occupied() == false)
		{
			m_direction = DIRECTION.UP;
			m_square.m_board.Start_Move_Object(this, m_square.m_above, m_direction, m_speed, true);
		}
		
		// we cannot move so deactivate
		else
		{
			m_square.m_active = true;
			m_horizontal_velocity = 0;	
			m_verticle_velocity = 0;
			
			// force a call to update and spin the monster in place, normally does not get called in this situation so monster stops moving
			Process_Move();
		}
	}
	
	public void Process_Original()
	{
		// Eat the object if the object is the right turn path of the monster we will move there below
		
		if ((m_square.m_below.Occupied() == true) && (m_square.m_below.m_object.m_eatable) && (m_direction == DIRECTION.RIGHT))
		{
			m_square.m_below.m_object.Eat(this);
		}
		else if ((m_square.m_above.Occupied() == true) && (m_square.m_above.m_object.m_eatable) && (m_direction == DIRECTION.LEFT))
		{
			m_square.m_above.m_object.Eat(this);
		}
		else if ((m_square.m_right.Occupied() == true) && (m_square.m_right.m_object.m_eatable) && (m_direction == DIRECTION.UP))
		{
			m_square.m_right.m_object.Eat(this);
		}
		else if ((m_square.m_left.Occupied() == true) && (m_square.m_left.m_object.m_eatable) && (m_direction == DIRECTION.DOWN))
		{
			m_square.m_left.m_object.Eat(this);
		}			
		
		// Eat the object if the object is in front of the monster and the monster is moving in that direction and then move there instead of any other move
		
		SQUARE square;
		
		square = m_square.Get_Square_Forward(m_direction);
		if ((square.Occupied() == true) && (square.m_object.m_eatable))
		{
			square.m_object.Eat(this);
			m_square.m_board.Start_Move_Object(this, square, m_direction, m_speed, true);
		}
		// continue moving the monster up if there still is an object to the right of the monster
		else if ((m_square.m_right.Occupied() == true) &&
			(m_square.m_above.Occupied() == false) &&
			(m_verticle_velocity > 0))
		{
			m_direction = DIRECTION.UP;
			m_square.m_board.Start_Move_Object(this, m_square.m_above, m_direction, m_speed, true);
		}
		else if ((m_square.m_right.m_below.Occupied() == true) &&
			(m_square.m_right.Occupied() == false) &&
			(m_direction == DIRECTION.UP))
		{
			m_direction = DIRECTION.RIGHT;
			m_square.m_board.Start_Move_Object(this, m_square.m_right, m_direction, m_speed, true);
		}
		// continue moving the monster to the right if there still is an object below the monster
		else if ((m_square.m_below.Occupied() == true) && 
			(m_square.m_right.Occupied() == false) &&
			(m_horizontal_velocity > 0))
		{
			m_direction = DIRECTION.RIGHT;
			m_square.m_board.Start_Move_Object(this, m_square.m_right, m_direction, m_speed, true);
		}
		else if ((m_square.m_below.m_left.Occupied() == true) &&
			(m_square.m_below.Occupied() == false) &&
			(m_horizontal_velocity > 0))
		{
			m_direction = DIRECTION.DOWN;
			m_square.m_board.Start_Move_Object(this, m_square.m_below, m_direction, m_speed, true);
		}
		else if ((m_square.m_left.Occupied() == true) &&
			(m_square.m_below.Occupied() == false) &&
			(m_verticle_velocity < 0))
		{
			m_direction = DIRECTION.DOWN;
			m_square.m_board.Start_Move_Object(this, m_square.m_below, m_direction, m_speed, true);
		}
		else if ((m_square.m_left.m_above.Occupied() == true) &&
			(m_square.m_left.Occupied() == false) &&
			(m_verticle_velocity < 0))
		{
			m_direction = DIRECTION.LEFT;
			m_square.m_board.Start_Move_Object(this, m_square.m_left, m_direction, m_speed, true);
		}
		else if ((m_square.m_above.Occupied() == true) &&
			(m_square.m_left.Occupied() == false) &&
			(m_horizontal_velocity < 0))
		{
			m_direction = DIRECTION.LEFT;
			m_square.m_board.Start_Move_Object(this, m_square.m_left, m_direction, m_speed, true);
		}
		else if ((m_square.m_above.m_right.Occupied() == true) &&
			(m_square.m_above.Occupied() == false) &&
			(m_horizontal_velocity < 0))
		{
			m_direction = DIRECTION.UP;
			m_square.m_board.Start_Move_Object(this, m_square.m_above, m_direction, m_speed, true);
		}
		else if ((m_square.m_above.Occupied() == true) &&
			(m_square.m_right.Occupied() == true) &&
			(m_square.m_left.Occupied() == false) &&
			(m_verticle_velocity > 0))
		{
			m_direction = DIRECTION.LEFT;
			m_square.m_board.Start_Move_Object(this, m_square.m_left, m_direction, m_speed, true);
		}
		else if ((m_square.m_below.Occupied() == true) &&
			(m_square.m_left.Occupied() == true) &&
			(m_square.m_right.Occupied() == false) &&
			(m_verticle_velocity < 0))
		{
			m_direction = DIRECTION.RIGHT;
			m_square.m_board.Start_Move_Object(this, m_square.m_right, m_direction, m_speed, true);
		}
		else if ((m_square.m_right.Occupied() == true) &&
			(m_square.m_below.Occupied() == true) &&
			(m_square.m_above.Occupied() == false) &&
			(m_horizontal_velocity > 0))
		{
			m_direction = DIRECTION.UP;
			m_square.m_board.Start_Move_Object(this, m_square.m_above, m_direction, m_speed, true);
		}
		else if ((m_square.m_left.Occupied() == true) &&
			(m_square.m_above.Occupied() == true) &&
			(m_square.m_below.Occupied() == false) &&
			(m_horizontal_velocity < 0))
		{
			m_direction = DIRECTION.DOWN;
			m_square.m_board.Start_Move_Object(this, m_square.m_below, m_direction, m_speed, true);
		}
		// start things out to the left
		else if (m_square.m_left.Occupied() == false)
		{
			m_direction = DIRECTION.LEFT;
			m_square.m_board.Start_Move_Object(this, m_square.m_left, m_direction, m_speed, true);
		}
		else if (m_square.m_above.Occupied() == false)
		{
			m_direction = DIRECTION.UP;
			m_square.m_board.Start_Move_Object(this, m_square.m_above, m_direction, m_speed, true);
		}
		else if (m_square.m_right.Occupied() == false)
		{
			m_direction = DIRECTION.RIGHT;
			m_square.m_board.Start_Move_Object(this, m_square.m_right, m_direction, m_speed, true);
		}
		else if (m_square.m_below.Occupied() == false)
		{
			m_direction = DIRECTION.DOWN;
			m_square.m_board.Start_Move_Object(this, m_square.m_below, m_direction, m_speed, true);
		}
		else
		{
			// we cannot move so deactivate
			m_square.m_active = true;
			m_horizontal_velocity = 0;	
			m_verticle_velocity = 0;
			
			// force a call to update and spin the monster in place, normally does not get called in this situation so monster stops moving
			Process_Move();
		}
	}
	
	public override void Process_Move()
	{
		Process_Move_For_Round_Stationary_Objects();
	}
};

public class PLAYER: OBJECT
{
	float m_move_speed;
	float m_push_speed;
	float m_pickup_speed;
	float m_push_object_speed;
	float m_last_drill_time;
	float m_delay_drill_time;
	float m_dig_speed;
	float m_open_speed;
	//GameObject m_line_renderer_object;
	
	DIRECTION m_direction;
	Joystick m_joystick_script;
	GUITexture m_joystick_thumb;
	
	AudioClip m_drill_sound;
	AudioClip m_crush_sound;
	bool m_place_bomb_on_next_move;
	GameObject m_shot_object;
	float m_start_shot_time;
	Vector3 m_shot_start;
	Vector3 m_shot_end;
	Object m_shot_resource;
	//public LineRenderer m_line_renderer;
	//public Material m_line_material;
	
	public override void Destroy()
	{
		GameObject.Destroy(m_shot_object);
		m_shot_object = null;
		GameObject.Destroy(m_game_object);
		m_game_object = null;
	}
	
	public override bool Eat(OBJECT eater)
	{
		m_square.m_board.Remove_Object(this);
		
		m_square.Activate_All_Around_Square();

		m_square.m_board.m_player_died = true;
		m_square.m_board.m_player_died_time = Time.time;
		
		return true;
	}

	public override bool Crush()
	{
		Vector3 save_position = m_game_object.transform.position;;
		m_square.Splat_Crystals();
		
		AudioSource.PlayClipAtPoint(m_crush_sound, save_position);

		m_square.m_board.m_player_died = true;
		m_square.m_board.m_player_died_time = Time.time;
		
		return true;
	}
	
	public override bool Explode()
	{
		m_square.Splat_Crystals();
		
		m_square.m_board.m_player_died = true;
		m_square.m_board.m_player_died_time = Time.time;
		
		return true;
	}
	
	public override void Initialize()
	{
		Initialize_Object();
		
		m_direction = DIRECTION.RIGHT;
		
		m_round = true;
		m_crushable = true;
		m_eatable = true;
		m_explodeable = true;
		
		m_game_object = GameObject.Instantiate(Resources.Load("Player"), Vector3.zero, Quaternion.identity) as GameObject;
		
		m_place_bomb_on_next_move = false;
		
		// attach the player to the camera
		GameObject camera;		
		camera = GameObject.Find("Camera");
		SmoothLookAt script = camera.GetComponent("SmoothLookAt") as SmoothLookAt;
		script.target = m_game_object.transform;
		
		// attach the player to the spot light
		GameObject light;		
		light = GameObject.Find("Spot light");
		SmoothLookAt script2 = light.GetComponent("SmoothLookAt") as SmoothLookAt;
		script2.target = m_game_object.transform;
		
		// attach the player to the joystick
		GameObject joystick;		
		joystick = GameObject.Find("Single Joystick");
		m_joystick_script = joystick.GetComponent("Joystick") as Joystick;
		//m_joystick_thumb = joystick.GetComponent("JoystickThumb") as GUITexture;
		
		//if (Application.platform == RuntimePlatform.Android)
		//{
		//	m_joystick_thumb.enabled = true;
		//}
			
		m_drill_sound = MINE_AUDIO.Instance.m_drill_sound;
		m_crush_sound = MINE_AUDIO.Instance.m_crush_sound;
		m_moving_sound = MINE_AUDIO.Instance.m_moving_sound;
		
		m_move_speed = 8.0f;
		m_push_speed = 4.0f;
		m_pickup_speed = 6.0f;
		m_push_object_speed = 6.0f;
		m_dig_speed = 7.0f;
		m_open_speed = 5.0f;
		
		// initialize time to now
		m_last_drill_time = Time.time;
		m_delay_drill_time = 0.25f;
		
		m_shot_resource = Resources.Load("Shot");
		m_shot_object = null;
		
		//m_line_renderer_object = GameObject.Instantiate(Resources.Load("Player laser"), Vector3.zero, Quaternion.identity) as GameObject;
		//m_line_renderer = GameObject.Find("LineRenderer") as LineRenderer;
		//m_line_renderer = m_line_renderer_object.GetComponent("LineRenderer") as LineRenderer;
		//m_line_material = m_game_object.GetMaterial("Laser Material") as Material;
		//m_line_renderer.SetWidth(0.1f, 0.1f);
	}
	
	void Process_Shot()
	{
		OBJECT intersect_object;
		
		if (m_shot_object != null)
		{
			float translate = (Time.time - m_start_shot_time) * 3.0f;
			
			if (translate >= 1.0f)
			{
				GameObject.Destroy(m_shot_object);
				m_shot_object = null;
			}
			else
			{
				m_shot_object.transform.position = Vector3.Lerp(m_shot_start, m_shot_end, translate);
				m_square.m_active = true;
				intersect_object = null;
				
				intersect_object = m_square.m_board.Process_Objects_Shot_Intersects(m_shot_object, this);
				
				if (intersect_object != null)
				{
					if (intersect_object.m_drillable == true)
					{
						intersect_object.Drill();
					}
					
					GameObject.Destroy(m_shot_object);
					m_shot_object = null;
				}
			}
		}
		else if ((Input.GetAxis("Fire1") > 0) && (m_direction != DIRECTION.NONE))
		{
			m_shot_object = GameObject.Instantiate(m_shot_resource, m_game_object.transform.position, Quaternion.identity) as GameObject;
			
			m_shot_start = m_game_object.transform.position;
			
			switch (m_direction)
			{
				case DIRECTION.RIGHT:
 					m_shot_end.x = m_shot_start.x + m_square.m_board.m_square_size * 3;
					m_shot_end.y = m_shot_start.y; 
				break;
				case DIRECTION.LEFT:
					m_shot_end.x = m_shot_start.x - m_square.m_board.m_square_size * 3;
					m_shot_end.y = m_shot_start.y; 
				break;
				case DIRECTION.UP:
					m_shot_end.x = m_shot_start.x;
					m_shot_end.y = m_shot_start.y + m_square.m_board.m_square_size * 3; 
				break;
				case DIRECTION.DOWN:
					m_shot_end.x = m_shot_start.x;
					m_shot_end.y = m_shot_start.y - m_square.m_board.m_square_size * 3; 
				break;
			}
			m_shot_end.z = m_shot_start.z;
			
			m_start_shot_time = Time.time;
			
			m_square.m_active = true;
		}
	}
	
	public DIRECTION Get_Player_Input_Direction()
	{
		if (Input.GetAxis("Vertical") < 0)
		{
			return DIRECTION.DOWN;
		}
		else if (Input.GetAxis("Vertical") > 0)
		{
			return DIRECTION.UP;
		}
		else if (Input.GetAxis("Horizontal") < 0)
		{
			return DIRECTION.LEFT;
		}
		else if (Input.GetAxis("Horizontal") > 0)
		{
			return DIRECTION.RIGHT;
		}
		else
		{
			return DIRECTION.NONE;
		}
	}
	
	public override void Process()
	{
		DIRECTION input_direction = Get_Player_Input_Direction();
		float current_time;
		
		// set one end of the line to the player object
		//m_line_renderer.SetPosition(0, m_game_object.transform.position);
		
		// set the other to the direction we are pointing
		//m_line_renderer.SetPosition(1, m_square.Get_Square_Forward(m_direction).Get_First_Occupied_Square(m_direction).m_object.m_game_object.transform.position);
		
		float scrollSpeed = 1.0f;
		float noiseSize = 1.0f;
		
		//m_line_renderer.renderer.material.mainTextureOffset = new Vector2 (-Time.time * scrollSpeed, 0.0f);
		//m_line_renderer.renderer.material.mainTextureScale = new Vector2 (0.1f * noiseSize, noiseSize);		

		current_time = Time.time;
		
		if (Input.GetAxis("Fire3") > 0)
		{
			m_place_bomb_on_next_move = true;
		}

		if (input_direction != DIRECTION.NONE)
		{
			SQUARE direction_square = m_square.Get_Square_Forward(input_direction);
			
			if (direction_square.Occupied() == false)
			{
				m_square.m_board.Start_Move_Object(this, direction_square, input_direction, m_move_speed, true);
				
				if (m_place_bomb_on_next_move == true)
				{
					m_place_bomb_on_next_move = false;

					BOMB bomb = new BOMB();
					
					bomb.Initialize();

					m_square.m_object = null;
					m_square.m_board.Place_Object(bomb, m_square);				
				}
			}
			else if ((direction_square.m_object.m_pickupable == true) && (direction_square.m_object.Pickup(this) == true))
			{
				m_square.m_board.Start_Move_Object(this, direction_square, input_direction, m_pickup_speed, true);
				
				if (m_place_bomb_on_next_move == true)
				{
					m_place_bomb_on_next_move = false;

					BOMB bomb = new BOMB();
					
					bomb.Initialize();

					m_square.m_object = null;
					m_square.m_board.Place_Object(bomb, m_square);				
				}
			}
			else if ((direction_square.m_object.m_pushable == true) && (direction_square.m_object.Push(m_push_object_speed, input_direction, true) == true))
			{
				m_square.m_board.Start_Move_Object(this, direction_square, input_direction, m_push_speed, true);
				
				if (m_place_bomb_on_next_move == true)
				{
					m_place_bomb_on_next_move = false;

					BOMB bomb = new BOMB();
					
					bomb.Initialize();
					
					m_square.m_object = null;
					m_square.m_board.Place_Object(bomb, m_square);				
				}
			}
			else if ((direction_square.m_object.m_openable == true) && (direction_square.m_object.Open() == true))
			{
				// need to get the direction square because it may have changed after opening
				direction_square = m_square.Get_Square_Forward(input_direction);
				
				m_square.m_board.Start_Move_Object(this, direction_square, input_direction, m_open_speed, true);
				
				if (m_place_bomb_on_next_move == true)
				{
					m_place_bomb_on_next_move = false;

					BOMB bomb = new BOMB();
					
					bomb.Initialize();
					
					m_square.m_object = null;
					m_square.m_board.Place_Object(bomb, m_square);				
				}
			}
			// automatic drill on
			else if (((Application.platform == RuntimePlatform.Android) || (SCORE.m_auto_drill == true)) && ((current_time - m_last_drill_time) > m_delay_drill_time))
			{
				if (direction_square.m_object.Drill())
				{
					this.m_game_object.GetComponent<AudioSource>().PlayOneShot(m_drill_sound);
					m_last_drill_time = current_time;
					if (direction_square.Occupied() == false)
					{
						m_square.m_board.Start_Move_Object(this, direction_square, input_direction, m_move_speed, true);
						
						if (m_place_bomb_on_next_move == true)
						{
							m_place_bomb_on_next_move = false;
		
							BOMB bomb = new BOMB();
							
							bomb.Initialize();
		
							m_square.m_object = null;
							m_square.m_board.Place_Object(bomb, m_square);				
						}
					}
				}
			}
			
			m_direction = input_direction;
		}
		else
		{
			if ((m_square.m_conveyor_belt == true) &&
				(m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction).Occupied() == false))			
			{
				m_square.m_board.Start_Move_Object(this, m_square.Get_Square_Forward(m_square.m_conveyor_belt_direction), m_square.m_conveyor_belt_direction, m_square.m_conveyor_belt_speed, false);
			}
			else if ((m_square.m_pipe == true) &&
				(m_square.Get_Square_Forward(m_square.m_pipe_flow_down_direction).Occupied() == false))
			{
				// we are in a pipe, let's try going with the flow
				m_square.m_board.Start_Move_Object(this, m_square.Get_Square_Forward(m_square.m_pipe_flow_down_direction), m_square.m_pipe_flow_down_direction, m_square.m_pipe_flow_speed, true);
				m_direction = m_square.m_pipe_flow_down_direction;
			}
		}
/*		
		if (Input.GetKeyDown(KeyCode.Space) && (m_direction != DIRECTION.NONE))
		{
			SQUARE square = m_square.Get_Square_Forward(m_direction);
			if (square.Occupied() == true)
			{
				if ((Time.time - m_last_drill_time) > m_delay_drill_time)
				{
					this.m_game_object.audio.PlayOneShot(m_drill_sound);
					if (square.m_object.Drill())
					{
						m_last_drill_time = current_time;
					}
				}
			}
		}
*/		
		Process_Shot();
		
/*		
		if (Input.GetKeyDown(KeyCode.LeftControl) && (m_direction != DIRECTION.NONE))
		{
			SQUARE square = m_square.Get_Square_Forward(m_direction);
			if (square.Occupied() == false)
			{
				BOMB bomb = new BOMB();
				
				bomb.Initialize();
				
				m_square.m_board.Place_Object(bomb, square);
				
				bomb = null;
			}
		}
		*/
	}
	
	public override void Process_Move()
	{
		// set one end of the line to the player object
		//m_line_renderer.SetPosition(0, m_game_object.transform.position);
		
		// set the other to the direction we are pointing
		//m_line_renderer.SetPosition(1, m_square.Get_Square_Forward(m_direction).Get_First_Occupied_Square(m_direction).m_object.m_game_object.transform.position);
		
		float scrollSpeed = 1.0f;
		float noiseSize = 1.0f;
		//renderer.material.mainTexture
//		m_line_renderer.renderer.material.mainTextureOffset ..SetTextureOffset ("_MainTex", new Vector2 (-Time.time * scrollSpeed, 0.0f));
		//m_line_renderer.renderer.material.mainTextureOffset = new Vector2 (-Time.time * scrollSpeed, 0.0f);
//		m_line_renderer.renderer.material.SetTextureScale ("_MainTex", new Vector2 (0.1f * noiseSize, noiseSize));		
		//m_line_renderer.renderer.material.mainTextureScale = new Vector2 (0.1f * noiseSize, noiseSize);		

		if (Input.GetAxis("Fire3") > 0)
		{
			m_place_bomb_on_next_move = true;
		}
		
		Process_Shot();
	
		Process_Move_For_Round_Stationary_Objects();
	}
};

public class SQUARE
{
	public int m_row;
	public int m_column;
	
	public bool m_entrance;
	public bool m_exit;
	
	public SQUARE m_left;
	public SQUARE m_right;
	public SQUARE m_above;
	public SQUARE m_below;

	public bool m_active;
	public OBJECT m_object;

	public BOARD m_board;
	
	public DIRECTION m_pipe_flow_down_direction;
	public DIRECTION m_pipe_flow_up_direction;
	public float m_pipe_flow_speed;
	public bool m_pipe;
	
	public bool m_conveyor_belt;
	public DIRECTION m_conveyor_belt_direction;
	public float m_conveyor_belt_speed;

	public void Initialize()
	{
		m_board = null;
	
		m_row = 0;
		m_column = 0;
		m_entrance = false;
		m_exit = false;
		
		m_object = null;
		m_active = false;
		
		m_left = null;
		m_right = null;
		m_above = null;
		m_below = null;
		
		m_pipe_flow_down_direction = DIRECTION.NONE;
		m_pipe_flow_up_direction = DIRECTION.NONE;
		m_pipe = false;
		
		m_conveyor_belt = false;
		m_conveyor_belt_direction = DIRECTION.NONE;
		m_conveyor_belt_speed = 0.0f;
	}
	
	public void Set_Adjacent(SQUARE left, SQUARE right, SQUARE above, SQUARE below)
	{
		m_left = left;
		m_right = right;
		m_above = above;
		m_below = below;
	}
	
	public void Activate_All_Around_Square()
	{
		// including those that might only be visible around pipes
		m_right.m_above.m_active = true;
		m_right.m_below.m_active = true;
		m_left.m_above.m_active = true;
		m_left.m_below.m_active = true;

		m_above.m_active = true;
		m_below.m_active = true;
		m_left.m_active = true;
		m_right.m_active = true;
		
		m_above.m_right.m_active = true;
		m_above.m_left.m_active = true;
		m_below.m_right.m_active = true;
		m_below.m_left.m_active = true;	
	}
	
	public bool Occupied()
	{
		if (m_object == null)
		{
			// nothing in square
			return false;
		}
		
		return true;
	}

	public bool Occupied(DIRECTION enter_direction, float enter_velocity)
	{
		float horizontal_velocity;
		float verticle_velocity;
		
		switch (enter_direction)
		{
			case DIRECTION.UP:
			{
				horizontal_velocity = 0.0f;
				verticle_velocity = enter_velocity;
				break;
			}
			case DIRECTION.DOWN:
			{
				horizontal_velocity = 0.0f;
				verticle_velocity = -enter_velocity;
				break;
			}
			case DIRECTION.LEFT:
			{
				horizontal_velocity = -enter_velocity;
				verticle_velocity = 0.0f;
				break;
			}
			case DIRECTION.RIGHT:
			{
				horizontal_velocity = enter_velocity;
				verticle_velocity = 0.0f;
				break;
			}
			default:
			{
				horizontal_velocity = 0.0f;
				verticle_velocity = 0.0f;
				break;
			}
		}
		
		return Occupied(horizontal_velocity, verticle_velocity);
	}
	
	public bool Occupied(float enter_horizontal_velocity, float enter_verticle_velocity)
	{
		if (m_object == null)
		{
			// nothing in square
			return false;
		}
		else if (m_object.m_new_square == this)
		{
			// moving to this square so it is occupied
			return true;
		}
		else if ((m_object.m_horizontal_velocity == enter_horizontal_velocity) && (m_object.m_verticle_velocity == enter_verticle_velocity))
		{
			// we are moving out of the square at the same speed and direction as we want to move into it so return false
			return false;
		}
		// TODO need to check relative speeds and see if we can move in just as the other object is moving out
		// TODO need to check round objects to see if they can clear each other in time if they are moving perpendicular to each other.
		else if (((Mathf.Abs(m_object.m_horizontal_velocity + m_object.m_verticle_velocity) 
			* (Time.time - m_object.m_start_move_time)) / m_object.m_velocity_resolution) >= 0.7f)
		{
			// need to see if it has moved out of this square sufficiently so we can move in behind it.
			return false;
		}
		
		return true;
	}
	
	public SQUARE Get_Square_Forward(DIRECTION direction)
	{
		switch (direction)
		{
			case DIRECTION.UP:
			{
				return m_above;
			}
			case DIRECTION.DOWN:
			{
				return m_below;
			}
			case DIRECTION.LEFT:
			{
				return m_left;
			}
			case DIRECTION.RIGHT:
			{
				return m_right;
			}
			default:
			{
				return null;
			}
		}
	}
	
	public SQUARE Get_Square_Left(DIRECTION direction)
	{
		switch (direction)
		{
			case DIRECTION.UP:
			{
				return m_left;
			}
			case DIRECTION.DOWN:
			{
				return m_right;
			}
			case DIRECTION.LEFT:
			{
				return m_above;
			}
			case DIRECTION.RIGHT:
			{
				return m_below;
			}
			default:
			{
				return null;
			}
		}
	}
	
	public SQUARE Get_Square_Right(DIRECTION direction)
	{
		switch (direction)
		{
			case DIRECTION.UP:
			{
				return m_right;
			}
			case DIRECTION.DOWN:
			{
				return m_left;
			}
			case DIRECTION.LEFT:
			{
				return m_below;
			}
			case DIRECTION.RIGHT:
			{
				return m_above;
			}
			default:
			{
				return null;
			}
		}
	}
	
	public SQUARE Get_Square_Behind(DIRECTION direction)
	{
		switch (direction)
		{
			case DIRECTION.UP:
			{
				return m_below;
			}
			case DIRECTION.DOWN:
			{
				return m_above;
			}
			case DIRECTION.LEFT:
			{
				return m_right;
			}
			case DIRECTION.RIGHT:
			{
				return m_left;
			}
			default:
			{
				return null;
			}
		}
	}
	
	public SQUARE Get_First_Occupied_Square(DIRECTION direction)
	{
		SQUARE square;
		
		square = this;
		
		do 
		{
			square = square.Get_Square_Forward(direction);
		} while (square.Occupied() == false);
		
		return square;
	}
	
	public DIRECTION Get_Direction_Front(DIRECTION direction)
	{
		return direction;
	}
	
	public DIRECTION Get_Direction_Left(DIRECTION direction)
	{
		switch (direction)
		{
			case DIRECTION.UP:
			{
				return DIRECTION.LEFT;
			}
			case DIRECTION.DOWN:
			{
				return DIRECTION.RIGHT;
			}
			case DIRECTION.LEFT:
			{
				return DIRECTION.UP;
			}
			case DIRECTION.RIGHT:
			{
				return DIRECTION.DOWN;
			}
			default:
			{
				return DIRECTION.NONE;
			}
		}
	}
	
	public DIRECTION Get_Direction_Right(DIRECTION direction)
	{
		switch (direction)
		{
			case DIRECTION.UP:
			{
				return DIRECTION.RIGHT;
			}
			case DIRECTION.DOWN:
			{
				return DIRECTION.LEFT;
			}
			case DIRECTION.LEFT:
			{
				return DIRECTION.DOWN;
			}
			case DIRECTION.RIGHT:
			{
				return DIRECTION.UP;
			}
			default:
			{
				return DIRECTION.NONE;
			}
		}
	}
	
	public DIRECTION Get_Direction_Behind(DIRECTION direction)
	{
		switch (direction)
		{
			case DIRECTION.UP:
			{
				return DIRECTION.DOWN;
			}
			case DIRECTION.DOWN:
			{
				return DIRECTION.UP;
			}
			case DIRECTION.LEFT:
			{
				return DIRECTION.RIGHT;
			}
			case DIRECTION.RIGHT:
			{
				return DIRECTION.LEFT;
			}
			default:
			{
				return DIRECTION.NONE;
			}
		}
	}
	
	public void Splat_Crystals()
	{
		CRYSTAL crystal;
		// TODO: this might accidentlly place a crystal on a start point, monster eat
		
		// remove the object first in case it is moving between squares and will prevent some splat
		m_board.Remove_Object(m_object);
		
		// putting a cystal in the center will stop a ball rolling down so it will not crush the item below it
//		crystal = new CRYSTAL();
//		crystal.Initialize();
//		m_board.Place_Object(crystal, this);
		
		if (m_above.Occupied() == false)
		{
			crystal = new CRYSTAL();
			crystal.Initialize();
			m_board.Place_Object(crystal, m_above);
		}
		
		if (m_above.m_left.Occupied() == false)
		{
			crystal = new CRYSTAL();
			crystal.Initialize();
			m_board.Place_Object(crystal, m_above.m_left);
		}
		
		if (m_above.m_right.Occupied() == false)
		{
			crystal = new CRYSTAL();
			crystal.Initialize();
			m_board.Place_Object(crystal, m_above.m_right);
		}
		
		if (m_left.Occupied() == false)
		{
			crystal = new CRYSTAL();
			crystal.Initialize();
			m_board.Place_Object(crystal, m_left);
		}
		
		if (m_right.Occupied() == false)
		{
			crystal = new CRYSTAL();
			crystal.Initialize();
			m_board.Place_Object(crystal, m_right);
		}
		
		if (m_below.Occupied() == false)
		{
			crystal = new CRYSTAL();
			crystal.Initialize();
			m_board.Place_Object(crystal, m_below);
		}
		
		if (m_below.m_left.Occupied() == false)
		{
			crystal = new CRYSTAL();
			crystal.Initialize();
			m_board.Place_Object(crystal, m_below.m_left);
		}
		
		if (m_below.m_right.Occupied() == false)
		{
			crystal = new CRYSTAL();
			crystal.Initialize();
			m_board.Place_Object(crystal, m_below.m_right);
		}
	}
};

public abstract class BOARD
{
	// global so we can move down the list if we are about to remove the next in the list
	OBJECT m_next_process_object;
	OBJECT m_next_process_intersects_object;
	OBJECT m_next_process_toggle_object;
	OBJECT m_next_process_destroy_object;
	
	public int m_width;
	public int m_height;
	
	public float m_square_size;
	public float m_depth;
	
	public SQUARE[,] m_squares;
	public OBJECT m_objects;
	
	public bool m_player_died;
	public float m_player_died_time;
	
	public bool m_player_exit;
	public float m_player_exit_time;
	
	public GameObject m_plane;
	
	public int m_quota;
	public int m_seconds;
	
	public SQUARE m_entrance_square;
	
	public void Initialize()
	{		
		m_width = 0;
		m_height = 0;
		m_player_died = false;
		m_player_died_time = 0;
		
		m_player_exit = false;
		
		m_squares = null;
		m_objects = null;
		
		m_objects = null;
		m_squares = null;
		
		m_plane = null;
		
		m_entrance_square = null;
		
		m_next_process_object = null;
		m_next_process_intersects_object = null;
		m_next_process_toggle_object = null;
		m_next_process_destroy_object = null;
	}
	
	public SQUARE Get_Square(int column, int row)
	{
		if (m_squares != null)
		{
			// return square at that location
			return m_squares[column,row];
		}
		else
		{
			// error, return zero
			Debug.Log("m_squares is null");
			return null;
		}
	}	
	
	public void Create(int width, int height, float square_size, float depth)
	{
		int column;
		int row;
		SQUARE square;
		
		m_width = width;
		m_height = height;
		
		m_square_size = square_size;
		m_depth = depth;
		
		// empty object list
		m_objects = null;
	
		// initialize & create array of square objects
		m_squares = new SQUARE[width,height];
		
		// create the squares
		for (column = 0; column < width; column++)
		{
			for (row = 0; row < height; row++)
			{
				square = new SQUARE();
				square.Initialize();
				square.m_column = column;
				square.m_row = row;
				square.m_board = this;
				m_squares[column, row] = square;
			}
		}
		
		// connect adjacent squares together with wrap
		for (column = 0; column < width; column++)
		{
			for (row = 0; row < height; row++)
			{
				square = m_squares[column, row];
				square.Set_Adjacent(
					Get_Square((((column - 1) + width) % width), row),
					Get_Square(((column + 1) % (width)), row),
					Get_Square(column, (((row - 1) + height) % height)),
					Get_Square(column,  ((row + 1) % height)));
			}
		}
		
		// move a plane just behind the squares		
		
		m_plane = GameObject.Instantiate(Resources.Load("Plane"), Vector3.zero, Quaternion.identity) as GameObject;
		
		// rotate it into position
		m_plane.transform.Rotate(new Vector3(0,270,90));
		
		// move it into place (odd vs even size require half square size adjustments
		m_plane.transform.Translate(-(square_size / 2) * (1 - (width % 2)) - m_plane.transform.position.x, 
				(square_size / 2) * (1 - (height % 2))- m_plane.transform.position.y, 
				(depth + square_size / 2) - m_plane.transform.position.z, Space.World);
		
		// scale it to fit
		m_plane.transform.localScale = new Vector3(height * 0.1f, 0.1f, width * 0.1f);
		
		// scale the texture to fit
		//plane.renderer.material.mainTextureScale = new Vector2(height * 0.1f, width * 0.1f);
		m_plane.GetComponent<Renderer>().material.mainTextureScale = new Vector2(height, width);
	}

	public void Place_Object(OBJECT theobject, int row, int column)
	{
		SQUARE square;
		
		square = m_squares[column, row];
		
		Place_Object(theobject, square);
	}

	public void Place_Object(OBJECT theobject, SQUARE square)
	{
		if (square.Occupied() == true)
		{
			// the square is occupied delete the existing object first
			Remove_Object(square.m_object);
		}
		
		if (theobject != null)
		{
			// add the object to the list
			theobject.m_next_object = m_objects;
			m_objects = theobject;
			
			Set_Position(theobject, square.m_row, square.m_column);
			
			// set the square reference
			theobject.SetSquare(square);
		}
	
		// update the square object reference and activate the square
		square.m_object = theobject;
		square.m_active = true;
	}
	
	public void Process_Objects()
	{
		OBJECT the_object;
		the_object = m_objects;
		
		// process all objects in active squares	
		while (the_object != null)
		{
			m_next_process_object = the_object.m_next_object;
			
			// process all objects that are moving to a new square
			if (the_object.m_new_square != null)
			{
				// Process_Move() is not allowed to delete anything, only finish moving an object to the next square 
				the_object.Process_Move();
				
				// update the last process move time
				the_object.m_last_move_time = Time.time;
			}
			// process all active objects
			else if ((the_object.m_square != null) && (the_object.m_square.m_active == true))
			{
				// this object could be delete while processing 
				// so make sure you are through with it before calling Process()
				the_object.Process();
			}
			// just make sure the object is in the correct location
			else
			{
				//the_object.Offset_Position(0,0,0); //TODO Remove?
			}
			
			// go to next object in the list, without referencing the current object, cause it might be gone
			// next_process_object will be updated by BOARD_Remove_Object() if it is also deleted
			the_object = m_next_process_object;
		}
		
		// done processing the list, zero the global
		m_next_process_object = null;
	}
	
	public OBJECT Process_Objects_Shot_Intersects(GameObject game_object, OBJECT not_this_object)
	{
		OBJECT the_object;
			
		the_object = m_objects;
		
		// process all objects in active squares	
		while (the_object != null)
		{
			m_next_process_intersects_object = the_object.m_next_object;
			
			if ((the_object.m_game_object != null) && (not_this_object != the_object))
			{
				if (!(the_object is ENTRANCE) && !(the_object is SWITCH_MOMENTARY) && !(the_object is MAGIC) && !(the_object is SWITCH_TOGGLE) && (game_object.GetComponent<Renderer>().bounds.Intersects(the_object.m_game_object.GetComponent<Renderer>().bounds) == true))
				{
					if (the_object is DOOR)
					{
						if ((the_object as DOOR).m_open == false)
						{
							return the_object;
						}
					}
					else
					{
						return the_object;
					}
				}
			}
			// go to next object in the list, without referencing the current object, cause it might be gone
			// next_process_object will be updated by BOARD_Remove_Object() if it is also deleted
			the_object = m_next_process_intersects_object;
		}
		
		// done processing the list, zero the global
		m_next_process_intersects_object = null;
		
		return null;
	}
	
	
	public void Toggle_Objects(OBJECT.OBJECT_COLOR color)
	{
		OBJECT the_object;
			
		the_object = m_objects;
		
		// process all objects in active squares	
		while (the_object != null)
		{
			m_next_process_toggle_object = the_object.m_next_object;
			
			// process all active objects that are in squares
			if ((the_object.m_square != null))
			{
				// this object could be delete while processing 
				// so make sure you are through with it before calling Toggle()
				the_object.Toggle(color);
			}
			
			// go to next object in the list, without referencing the current object, cause it might be gone
			// next_process_object will be updated by BOARD_Remove_Object() if it is also deleted
			the_object = m_next_process_toggle_object;
		}
		
		// done processing the list, zero the global
		m_next_process_toggle_object = null;
	}
	
	public void Destroy_Objects()
	{
		OBJECT the_object;
		OBJECT m_next_process_destroy_object;
		
		the_object = m_objects;
		
		// process all objects in active squares	
		while (the_object != null)
		{
			m_next_process_destroy_object = the_object.m_next_object;
			
			the_object.Destroy();
			
			// go to next object in the list, without referencing the current object, cause it might be gone
			// next_process_object will be updated by BOARD_Remove_Object() if it is also deleted
			the_object = m_next_process_destroy_object;
		}
		
		// Detroy the backgroud plane also.
		GameObject.Destroy(m_plane);
		
		// done processing the list, zero the global
		m_next_process_destroy_object = null;
	}
	
	public void Remove_Object(OBJECT theobject)
	{
		SQUARE square;
		OBJECT walk_object;
		
		if (theobject != null)
		{
			// remove this object from the square if the object has not already been replaced by a
			// moving object
			square = theobject.m_square;
			if (square != null)
			{
				square.Activate_All_Around_Square();
				
				if (square.m_object == theobject)
				{
					square.m_object = null;
				}
			}
				
			// if this object is moving to a new square remove it from here as well
			square = theobject.m_new_square;
			if (square != null)
			{
				square.Activate_All_Around_Square();

				if (square.m_object == theobject)
				{
					square.m_object = null;
				}
			}
			
			// is this object we are removing next to be processed
			// move down the list if it is, cause otherwise we will try 
			// and process a delete object
			if (m_next_process_object == theobject)
			{
				m_next_process_object = theobject.m_next_object;
			}

			if (m_next_process_intersects_object == theobject)
			{
				m_next_process_intersects_object = theobject.m_next_object;
			}

			if (m_next_process_destroy_object == theobject)
			{
				m_next_process_destroy_object = theobject.m_next_object;
			}

			// check if object is first in the list
			if (m_objects == theobject)
			{
				m_objects = m_objects.m_next_object;	
			}
			else
			{
				// find the object in the list and remove it
				walk_object = m_objects;
				
				while (walk_object != null)
				{
					// have we found the object yet
					if (walk_object.m_next_object == theobject)
					{
						// disconnect this object from the list
						walk_object.m_next_object = walk_object.m_next_object.m_next_object;
						
						// we found it so drop out of the loop
						walk_object = null;
					}
					else
					{
						// go to the next object in the list
						walk_object = walk_object.m_next_object;
						
						if (walk_object == null)
						{
							Debug.Log("object not found for removal\n");
						}
					}
				}
			}
			
			// finally delete the object
			GameObject.Destroy(theobject.m_game_object);
		}
	}	
	
	public void Start_Move_Object(
		OBJECT the_object, 
		SQUARE new_square, 
		DIRECTION direction,
		float velocity,
		bool rolling)
	{
		float horizontal_velocity;
		float verticle_velocity;
		
		if (velocity == 0.0f)
		{
			// we will never get there if we don't have some velocity
			velocity = 1.0f;
			Debug.Log("velocity is zero setting to 1 instead");
		}
		
		switch (direction)
		{
			case DIRECTION.UP:
			{
				horizontal_velocity = 0.0f;
				verticle_velocity = velocity;
				break;
			}
			case DIRECTION.DOWN:
			{
				horizontal_velocity = 0.0f;
				verticle_velocity = -velocity;
				break;
			}
			case DIRECTION.LEFT:
			{
				horizontal_velocity = -velocity;
				verticle_velocity = 0.0f;
				break;
			}
			case DIRECTION.RIGHT:
			{
				horizontal_velocity = velocity;
				verticle_velocity = 0.0f;
				break;
			}
			default:
			{
				horizontal_velocity = 0.0f;
				verticle_velocity = 0.0f;
				break;
			}
		}
		
		Start_Move_Object(the_object, new_square, horizontal_velocity, verticle_velocity, rolling);
	}
	
	public void Start_Move_Object(
		OBJECT the_object, 
		SQUARE new_square, 
		float horizontal_velocity,
		float verticle_velocity,
		bool rolling)
	{
		// put object in new square so it exists in both squares
		new_square.m_object = the_object;
		the_object.m_new_square = new_square;
		
		the_object.m_start_move_time = Time.time;
		the_object.m_last_move_time = the_object.m_start_move_time;
		
		the_object.m_horizontal_velocity = horizontal_velocity;
		the_object.m_verticle_velocity = verticle_velocity;
		the_object.m_rolling = rolling;
		
		// activate all 8 square around the new square
		new_square.Activate_All_Around_Square();

		SQUARE current_square;
		
		current_square = the_object.m_square;

		// activate all 8 square around the current square
		current_square.Activate_All_Around_Square();

		// this line may not be nessesary
		the_object.Process_Move();
	}

	public void Move_Object(OBJECT theobject, SQUARE new_square)
	{
		SQUARE current_square;
		
		current_square = theobject.m_square;
		
		// activate all 8 squares around this one we are moving
		current_square.Activate_All_Around_Square();
		
		// deactivate object's current square because it is now empty
		current_square.m_active = false;
	
		// if other object (specifically the player) is moving in behind don't remove it	
		// only remove it if it is this object behind it
		if (current_square.m_object == theobject)
		{
			current_square.m_object = null;
		}
		
		// set new drawing position
		Set_Position(theobject, new_square.m_row, new_square.m_column);
		
		// set the object's square reference
		theobject.SetSquare(new_square);
		
		// update the new square's object reference 
		new_square.m_object = theobject;
		
		// activate the square 
		new_square.m_active = true;
		
		// and all squares around it
		new_square.Activate_All_Around_Square();
		
		theobject.m_start_move_time = 0;
		theobject.m_last_move_time = 0;
		theobject.m_verticle_velocity = 0;
		theobject.m_horizontal_velocity = 0;
	}
	
	public void Set_Position(OBJECT the_object, int row, int column)
	{
		the_object.Set_Position(
			m_square_size * (column - (m_width /2)), 
			m_square_size * (-row + (m_height / 2)), 
			m_depth);
	}
};

public class MINE: BOARD
{
	public void Populate(int balls, int boxes, int balloons, int monsters, int bricks, int dirts, int crystals, int amoebas, int vertical_pipes, int horizontal_pipes, int left_elbows, int above_elbows, int teleports, int conveyor_belts)
	{
		int column;
		int row;
		int percent;
		
		OBJECT the_object = null;
		
		Random.seed = 1234;
		
		for (row = 0; row < m_height; row++)
		{
			for (column = 0; column < m_width; column++)
			{
				// put player in the middle of the board			
				if ((column == (m_width / 2)) && (row == (m_height / 2)))
				{
					the_object = new PLAYER();
				}
				else if ((column == 0) || ( row == 0) || (column == m_width - 1) || (row == m_height - 1))
				{
					the_object = new STONE();
				}
				else
				{
					// randomly place the other kinds of objects
					percent = Random.Range(0,100);
				
					if (percent < balls)
					{
						the_object = new STONE_BALL();
					}
					else if (percent < (balls + boxes))
					{
						the_object = new STONE_BOX();
					}
					else if (percent < (balls + boxes + balloons))
					{
						the_object = new BALLOON();
					}
					else if (percent < (balls + boxes + balloons + monsters))
					{
						the_object = new ROCK_MONSTER();
					}
					else if (percent < (balls + boxes + balloons + monsters + bricks))
					{
						the_object = new STONE();
					}
					else if (percent < (balls + boxes + balloons + monsters + bricks + dirts))
					{
						the_object = new DIRT();
					}
					else if (percent < (balls + boxes + balloons + monsters + bricks + dirts + crystals))
					{
						the_object = new CRYSTAL();
					}
					else if (percent < (balls + boxes + balloons + monsters + bricks + dirts + crystals + amoebas))
					{
						the_object = new AMOEBA();
					}
					else if (percent < (balls + boxes + balloons + monsters + bricks + dirts + crystals + amoebas + vertical_pipes))
					{
						the_object = new PIPE_VERTICAL();
					}
					else if (percent < (balls + boxes + balloons + monsters + bricks + dirts + crystals + amoebas + vertical_pipes + horizontal_pipes))
					{
						the_object = new PIPE_HORIZONTAL(DIRECTION.RIGHT);
					}
					else if (percent < (balls + boxes + balloons + monsters + bricks + dirts + crystals + amoebas + vertical_pipes + horizontal_pipes + left_elbows))
					{
						the_object = new PIPE_ELBOW_LEFT();
					}
					else if (percent < (balls + boxes + balloons + monsters + bricks + dirts + crystals + amoebas + vertical_pipes + horizontal_pipes + left_elbows + above_elbows))
					{
						the_object = new PIPE_ELBOW_ABOVE();
					}
					else if (percent < (balls + boxes + balloons + monsters + bricks + dirts + crystals + amoebas + vertical_pipes + horizontal_pipes + left_elbows + above_elbows + teleports))
					{
						the_object = new TELEPORT();
					}
					else if (percent < (balls + boxes + balloons + monsters + bricks + dirts + crystals + amoebas + vertical_pipes + horizontal_pipes + left_elbows + above_elbows + teleports + conveyor_belts))
					{
						the_object = new CONVEYOR_BELT(DIRECTION.RIGHT);
					}
				}
				
				if (the_object != null)
				{
					the_object.Initialize();
					Place_Object(the_object, row, column);
					// only allow the object to be placed once
					the_object = null;
				}
			}
		}
	}
	
	
	public void LoadMap(string filename, int square_size, int depth, int requested_level)
	{
		int width;
		int height;
		int row;
		int column;
		int object_code;
		int level;
//		int hidden_areas;
		
		int entrance_row = 1;
		int entrance_column = 1;
		
		OBJECT the_object;
		string line;

		StringReader sr = null; 
		
		TextAsset mapdata = (TextAsset)Resources.Load("MY.MAP", typeof(TextAsset));
		
		// puzdata.text is a string containing the whole file. To read it line-by-line:
		sr = new StringReader(mapdata.text);
		if ( sr == null )
		{
		   Debug.Log("MY.MAP not found or not readable");
		}
		else
		{
			do
			{
				do
				{
					line = sr.ReadLine();
				}
				while (line.Equals("Level") == false);
				int.TryParse(sr.ReadLine(), out level);
			}
			while (requested_level != level);
			
/*			
			int.TryParse(sr.ReadLine(), out hidden_areas);
			while (hidden_areas > 0)
			{
				int.TryParse(sr.ReadLine(), out row);
				int.TryParse(sr.ReadLine(), out column);
				int.TryParse(sr.ReadLine(), out width);
				int.TryParse(sr.ReadLine(), out height);
				
				// move a plane just behind the squares		
				m_plane = GameObject.Instantiate(Resources.Load("Plane"), Vector3.zero, Quaternion.identity) as GameObject;
				
				// rotate it into position
				m_plane.transform.Rotate(new Vector3(0,270,90));
				
				// move it into place (odd vs even size require half square size adjustments
				m_plane.transform.Translate(-(row + square_size / 2) * (1 - (width % 2)) - m_plane.transform.position.x, 
						(column + square_size / 2) * (1 - (height % 2))- m_plane.transform.position.y, 
						(depth - (square_size/2) - 0.5f) - m_plane.transform.position.z, Space.World);
				
				// scale it to fit
				m_plane.transform.localScale = new Vector3(height * 0.1f, 0.1f, width * 0.1f);
				
				// scale the texture to fit
				//plane.renderer.material.mainTextureScale = new Vector2(height * 0.1f, width * 0.1f);
				m_plane.renderer.material.mainTextureScale = new Vector2(height, width);
				
				hidden_areas--;
			}
*/			
			int.TryParse(sr.ReadLine(), out width);
			int.TryParse(sr.ReadLine(), out height);
			int.TryParse(sr.ReadLine(), out m_quota);
			int.TryParse(sr.ReadLine(), out m_seconds);
		
			Create(width, height, square_size, depth);
		
			for (row = 0; row < height; row++)
			{
				for (column = 0; column < width; column++)
				{
					// skip over white space
					do 
					{
						object_code = sr.Read();
					} while (object_code < ' ');
					
					switch (object_code)
					{
						case 'a':
						{
							the_object = new AMOEBA();
							break;
						}
						case ' ':
						{
							the_object = null;
							break;
						}
						case '.':
						{
							the_object = new DIRT();
							break;
						}
						case ',':
						{
							the_object = new DIRT_HARD();
							break;
						}
						case 'w':
						{
							the_object = new ROCK();
							break;
						}
						case 'W':
						{
							the_object = new STONE();
							break;
						}
						case 'P':
						{
							the_object = new ENTRANCE();
						
							// save location to place player at start
							entrance_row = row;
							entrance_column = column;
							break;
						}
						case 'r':
						{
							the_object = new STONE_BALL();
							break;
						}
						case 'R':
						{
							the_object = new ROCK_BALL();
							break;
						}
						case 'i':
						{
							the_object = new STONE_BOX();
							break;
						}
						case 'x':
						{
							the_object = new ROCK_BOX();
							break;
						}
						case 'y':
						{
							the_object = new SOFT_ROCK_BOX();
							break;
						}
						case 'Y':
						{
							the_object = new SOFT_ROCK();
							break;
						}
						case 'Z':
						{
							the_object = new SOFT_ROCK_BALL();
							break;
						}
						case 'Q':
						{
							the_object = new ROCK_MONSTER();
							break;
						}
						case 'q':
						{
							the_object = new ROCK_MONSTER();
							break;
						}
						case 'd':
						{
							the_object = new CRYSTAL();
							break;
						}
						case '@':
						{
							the_object = new CRYSTAL(CRYSTAL.GEM.CITRINE);
							break;
						}
						case '$':
						{
							the_object = new CRYSTAL(CRYSTAL.GEM.EMERALD);
							break;
						}
						case '%':
						{
							the_object = new CRYSTAL(CRYSTAL.GEM.RUBY);
							break;
						}
						case '^':
						{
							the_object = new CRYSTAL(CRYSTAL.GEM.SAPPHIRE);
							break;
						}
						case '&':
						{
							the_object = new CRYSTAL(CRYSTAL.GEM.TOPAZ);
							break;
						}
						case 'F':
						{
							the_object = new STONE_BREAKABLE();
							break;
						}
						case 'B':
						{
							the_object = new ROCK_MONSTER(); 
							break;
						}
						case 'C':
						{
							the_object = new ROCK_MONSTER();
							break;
						}
						case 'c':
						{
							the_object = new ROCK_MONSTER();
							break;
						}
						case 'O':
						{
							the_object = new ROCK_MONSTER();
							break;
						}
						case 'X':
						{
							the_object = new EXIT();
							break;
						}
						case '1':
						{
							the_object = new CONVEYOR_BELT(DIRECTION.RIGHT);
							break;
						}
						case '2':
						{
							the_object = new CONVEYOR_BELT(DIRECTION.LEFT);
							break;
						}
						case '3':
						{
							the_object = new CONVEYOR_BELT(DIRECTION.UP);
							break;
						}
						case '4':
						{
							the_object = new CONVEYOR_BELT(DIRECTION.DOWN);
							break;
						}
						case '5':
						{
							the_object = new PIPE_ELBOW_LEFT();
							break;
						}
						case '6':
						{
							the_object = new PIPE_ELBOW_ABOVE();
							break;
						}
						case '7':
						{
							the_object = new PIPE_ELBOW_RIGHT();
							break;
						}
						case '8':
						{
							the_object = new PIPE_ELBOW_DOWN();
							break;
						}
						case '9':
						{
							the_object = new PIPE_VERTICAL();
							break;
						}
						case '0':
						{
							the_object = new PIPE_HORIZONTAL(DIRECTION.LEFT);
							break;
						}
						case '`':
						{
							the_object = new PIPE_HORIZONTAL(DIRECTION.RIGHT);
							break;
						}
						case '+':
						{
							the_object = new PIPE_4WAY();
							break;
						}
						
						case '-':
						{
							the_object = new PIPE_3WAY();
							break;
						}
						
						case 'T':
						{
							the_object = new TELEPORT();
							break;
						}
						case 'b':
						{
							the_object = new BALLOON();
							break;
						}
						case 'D':
						{
							the_object = new DOOR(OBJECT.OBJECT_COLOR.BLUE);
							break;
						}
						case 'E':
						{
							the_object = new DOOR(OBJECT.OBJECT_COLOR.RED);
							break;
						}
						case 'f':
						{
							the_object = new DOOR(OBJECT.OBJECT_COLOR.YELLOW);
							break;
						}
						case 'e':
						{
							the_object = new DOOR(OBJECT.OBJECT_COLOR.GREEN);
							break;
						}
						case 'S':
						{
							the_object = new SWITCH_TOGGLE(OBJECT.OBJECT_COLOR.BLUE);
							break;
						}
						case 's':
						{
							the_object = new SWITCH_TOGGLE(OBJECT.OBJECT_COLOR.RED);
							break;
						}
						case 'M':
						{
							the_object = new SWITCH_MOMENTARY(OBJECT.OBJECT_COLOR.BLUE);
							break;
						}
						case 'n':
						{
							the_object = new SWITCH_MOMENTARY(OBJECT.OBJECT_COLOR.RED);
							break;
						}
						case 'm':
						{
							the_object = new MAGIC();
							break;
						}
						
						case ':':
						{
							the_object = new SAND_BOX();
							break;
						}
						
						case ';':
						{
							the_object = new SAND();
							break;
						}
						
						case 'L':
						{
							the_object = new LAVA();
							break;
						}
						
						case 'V':
						{
							the_object = new LAVA_STONE();
							break;
						}
						
						case 'l':
						{
							the_object = new LAVA_STONE_BOX();
							break;
						}
						
						case 'v':
						{
							the_object = new LAVA_STONE_BALL();
							break;
						}
						
						case 'H':
						{
							the_object = new ROCK_MONSTER_HIDDEN();
							break;
						}
						
						case 'o':
						{
							the_object = new NUGGET(NUGGET.ORE.GOLD);
							break;
						}
						
						case ']':
						{
							the_object = new NUGGET(NUGGET.ORE.COPPER);
							break;
						}
						
						case '[':
						{
							the_object = new NUGGET(NUGGET.ORE.SILVER);
							break;
						}
						
						case 'k':
						{
							the_object = new KEY(OBJECT.OBJECT_COLOR.YELLOW);
							break;
						}
						
						case 'K':
						{
							the_object = new KEY(OBJECT.OBJECT_COLOR.GREEN);
							break;
						}
						
						case '_':
						{
							the_object = new KEY(OBJECT.OBJECT_COLOR.BLUE);
							break;
						}
						
						case ')':
						{
							the_object = new KEY(OBJECT.OBJECT_COLOR.RED);
							break;
						}
						
						case 'I':
						{
							the_object = new INGOTS(INGOTS.ORE.GOLD);
							break;
						}
						
						default:
						{
							the_object = null;
							break;
						}
					}
					
					if (the_object != null)
					{
						the_object.Initialize();
						Place_Object(the_object, row, column);
						// only allow the object to be placed once
						the_object = null;
					}
				}
			}	
				
			SQUARE square = Get_Square(entrance_column, entrance_row);
			the_object = new PLAYER();
			the_object.Initialize();
			Place_Object(the_object, (square.m_object as ENTRANCE).m_entrance_square);
			the_object = null;
		}
	}
};

public static class SCORE 
{
	public static bool m_auto_drill = false;
	public static int m_score_point = 0;
	public static int m_score_point_this_level = 0;
	
	//TODO these need to be retained
	public static int m_number_of_blue_keys = 0;
	public static int m_number_of_red_keys = 0;
	public static int m_number_of_yellow_keys = 0;
	public static int m_number_of_green_keys = 0;
}

public class MINE_AUDIO
{
    private static MINE_AUDIO m_instance;
 	
	public AudioClip m_hit_sound;
	public AudioClip m_moving_sound;
	
	public AudioClip m_drill_sound;
	public AudioClip m_crush_sound;
	
	public AudioClip m_eat_sound;
	
	public AudioClip m_door_sound;
	
	public AudioClip m_pickup_sound;
	
	public AudioClip m_crystal_break_sound;
	public AudioClip m_crystal_hit_sound;
	
	public AudioClip m_bomb_sound;
	public AudioClip m_fuse_sound;

	private MINE_AUDIO() 
	{
		m_hit_sound = Resources.Load("Hit") as AudioClip;
		m_moving_sound = Resources.Load("Tires On Gravel Steady") as AudioClip;
		
		m_drill_sound = Resources.Load("Drill") as AudioClip;
		m_crush_sound = Resources.Load("Baseball Bat Hit") as AudioClip;
		
		m_eat_sound = Resources.Load("Eat") as AudioClip;
		
		m_door_sound = Resources.Load("Drill")as AudioClip;
		
		m_pickup_sound = Resources.Load("Pickup") as AudioClip;
		
		m_crystal_break_sound = Resources.Load("Break") as AudioClip;
		m_crystal_hit_sound = Resources.Load("Glass Clink Single") as AudioClip;
		
		m_bomb_sound = Resources.Load("Bomb Sound") as AudioClip;
		m_fuse_sound = Resources.Load("Fuse Sizzle") as AudioClip;
	}
	
	public static MINE_AUDIO Instance
	{
		get 
		{
			if (m_instance == null)
			{
				m_instance = new MINE_AUDIO();
			}
			return m_instance;
		}
	}

}

public class Minegame : MonoBehaviour 
{
	MINE m_mine;
	int level = 0;
	float m_start_level_time;
	static bool restart_flag = false;
	
	// Use this for initialization
	void Start() 
	{
		m_mine = new MINE();
		m_mine.Initialize();
		m_start_level_time = Time.time;		
		m_mine.LoadMap("MY.MAP.txt", 1, 2, level);
		
		//Time.
		//m_mine.Create(10, 10, 1, 15);
		//m_mine.Populate(15, 5, 5, 2, 5, 5, 15, 3, 3, 3, 3, 3, 1,10);
		//m_mine.Populate(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10);
	}
	
	// Update is called once per frame
	//void Update() 
	void LateUpdate() 
	//void FixedUpdate() 
	{
		if (m_mine != null)
		{
			// process all objects in the mine
			m_mine.Process_Objects();

			// if the player died, try to place the player back at the start point by waiting a bit for the square to be free otherwise just place the player back at the start point regardless
			if (m_mine.m_player_died == true)
			{

				if ((m_mine.m_player_died_time + 3 < Time.time) && (m_mine.m_entrance_square != null) && (m_mine.m_entrance_square.Occupied() == false))
				{
					PLAYER player;
					
					m_mine.m_player_died_time = 0;
					m_mine.m_player_died = false;
					
					player = new PLAYER();
					player.Initialize();
					m_mine.Place_Object(player, m_mine.m_entrance_square);
				}
				else if ((m_mine.m_player_died_time + 3 < Time.time) && (m_mine.m_squares[(m_mine.m_width / 2), (m_mine.m_height / 2)].Occupied() == false))
				{
					PLAYER player;
					
					m_mine.m_player_died_time = 0;
					m_mine.m_player_died = false;
					
					player = new PLAYER();
					player.Initialize();
					m_mine.Place_Object(player, (m_mine.m_width / 2), (m_mine.m_height / 2));
				}
				else if (m_mine.m_player_died_time + 8 < Time.time)
				{
					PLAYER player;
					
					m_mine.m_player_died_time = 0;
					m_mine.m_player_died = false;
					
					player = new PLAYER();
					player.Initialize();
					m_mine.Place_Object(player, (m_mine.m_width / 2), (m_mine.m_height / 2));
				}
			}
			
			// check if the player exited the mine, restart new level
			if ((m_mine.m_player_exit == true) && (m_mine.m_player_exit_time + 3 < Time.time))
			{
				m_mine.Destroy_Objects();
				
				m_mine = null;
				
				level++;
				m_start_level_time = Time.time;
				SCORE.m_score_point = SCORE.m_score_point + SCORE.m_score_point_this_level;
				SCORE.m_score_point_this_level = 0;
				SCORE.m_number_of_blue_keys = 0;
				SCORE.m_number_of_red_keys = 0;
				SCORE.m_number_of_yellow_keys = 0;
				SCORE.m_number_of_green_keys = 0;
				
				m_mine = new MINE();
				m_mine.Initialize();
				
				m_mine.LoadMap("MY.MAP.txt", 1, 5, level);
			}
		}

		// zoom camera
		GameObject camera;		
		camera = GameObject.Find("Camera");
		SmoothLookAt script = camera.GetComponent("SmoothLookAt") as SmoothLookAt;
		if (Input.GetAxis("Mouse ScrollWheel") < 0) // forward
		{
			script.depth = script.depth + 0.25f;
			
			if (script.depth > 20)
				script.depth = 20;
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0) // back
		{
			script.depth = script.depth - 0.25f;
			if (script.depth < 1)
				script.depth = 1;
		}
	
		// check for quit
		if ((Input.GetKeyDown(KeyCode.Escape) == true) || (Input.GetKeyDown(KeyCode.Q) == true))
		{
			Application.Quit();
		}
		
		// check for restart level
		if ((Input.GetKeyDown(KeyCode.R) == true) && (restart_flag == false))
		{
			restart_flag = true;
			
			if (m_mine != null)
			{
				m_mine.Destroy_Objects();
				
				m_mine = null;
			}
			
			SCORE.m_score_point_this_level = 0;
			SCORE.m_number_of_blue_keys = 0;
			SCORE.m_number_of_red_keys = 0;
			SCORE.m_number_of_yellow_keys = 0;
			SCORE.m_number_of_green_keys = 0;

			m_mine = new MINE();
			m_mine.Initialize();
			
			m_mine.LoadMap("MY.MAP.txt", 1, 5, level);
			restart_flag = false;
		}

		// check for next level
		if ((Input.GetKeyDown(KeyCode.Equals) == true) && (restart_flag == false))
		{
			restart_flag = true;
			
			if (m_mine != null)
			{
				m_mine.Destroy_Objects();
				
				m_mine = null;
			}
			
			level++;
			m_start_level_time = Time.time;
			SCORE.m_score_point_this_level = 0;
			SCORE.m_number_of_blue_keys = 0;
			SCORE.m_number_of_red_keys = 0;
			SCORE.m_number_of_yellow_keys = 0;
			SCORE.m_number_of_green_keys = 0;

			m_mine = new MINE();
			m_mine.Initialize();
			
			m_mine.LoadMap("MY.MAP.txt", 1, 5, level);
			restart_flag = false;
		}
		
		// check for previous level
		if ((Input.GetKeyDown(KeyCode.Minus) == true) && (restart_flag == false) && (level > 0))
		{
			restart_flag = true;
			
			if (m_mine != null)
			{
				m_mine.Destroy_Objects();
				
				m_mine = null;
			}
			
			level--;
			m_start_level_time = Time.time;
			SCORE.m_score_point_this_level = 0;
			SCORE.m_number_of_blue_keys = 0;
			SCORE.m_number_of_red_keys = 0;
			SCORE.m_number_of_yellow_keys = 0;
			SCORE.m_number_of_green_keys = 0;

			m_mine = new MINE();
			m_mine.Initialize();
			
			m_mine.LoadMap("MY.MAP.txt", 1, 5, level);
			restart_flag = false;
		}
		
		// check for previous level
		if (Input.GetKeyDown(KeyCode.Return) == true)
		{
			SCORE.m_auto_drill = !SCORE.m_auto_drill;
		}
	
		//OVRManager ovr = camera.GetComponent("OVRManager") as OVRManager;
		
		if(Input.GetKeyDown(KeyCode.F12) == true)
		{
			if (OVRManager.instance != null)
			{
				OVRManager.display.RecenterPose();
			}
		}
	}
	
	void OnGUI () 
	{
		// update score
		GUIText score_text = GameObject.Find("Score").GetComponent<GUIText>();
		if (score_text != null)
		{
			score_text.text = "Score " + (SCORE.m_score_point + SCORE.m_score_point_this_level);
		}
		
		GUIText timer_text = GameObject.Find("Timer").GetComponent<GUIText>();
		if (timer_text != null)
		{
			timer_text.text = "Time " + Mathf.CeilToInt(Time.time - m_start_level_time);
		}
	}
}