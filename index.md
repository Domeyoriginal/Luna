
# Week 1
I thought up of a project idea, got a lot of design work thought of, through for week 2. Had help from a friend thinking up of idea and I finalized it.
```
- Character Idea
- Enemy Idea
- Life Skills
- World Idea
- E.C.T
```
There was so much more i have planned out just not written, I will take all of week 2 to write up documentations while i Model the Enemy/Enemies and Character.
I had setup a Trello page as well which is in this [Link](https://trello.com/b/wYP5vaxr/luna-we).

With Week2 i will have much more to show for the blog.

# Week 2
I messed around a lot with particles and ideas for a monster, didnt get far as i had trouble deciding on the final design.
Instead i did up a moon cycle since the world will never see the sun, i needed a moon to alwasy rotate around the world and have the light get darker and brighter depending on the moons position. I want it this way for a buff of the monsters when its darker. The monsters get better and stronger from taking power of the drakness.

I had also messed around with the design for the main character, and the other NPC's. With the help of a friend for designing characters we picked out that each non monster npc will we surroudned in cloth to keep warm. There is no sun so there is no heat. The world will also be in an ice-age of sorts becuase of the sun.
I had made a moon system which followed a Sin wave, it also changed the light intensity the lower or higher the moon is.
Below is the code for it :
```
float angle = 90;
    float index;
    float speed = (2 * Mathf.PI) / 120; //[ / = seconds ]

    public float radius = 500;
    public float amplitudeY = 500.0f;
    public float omegaY = 1.0f;
    public float highestIntensity;
    
    void UpdateTime()
    {
        index += Time.deltaTime;
        angle += speed * Time.deltaTime;

        float x = Mathf.Sin(angle) * radius;
        float y = Mathf.Abs(amplitudeY * Mathf.Sin((omegaY * index) * speed));
        float z = Mathf.Cos(angle) * radius;

        //light and moon poisiton and rotation with worldCetre
        targetLight.transform.position = new Vector3(x, y/2 ,z);
        targetLight.transform.LookAt(centreOfWorld.transform);
        Moon.transform.position = targetLight.transform.position;
        Moon.transform.LookAt(centreOfWorld.transform);

        //light intensity with position of moon
        targetLight.GetComponent<Light>().intensity = (y / amplitudeY) * highestIntensity;
     }
```
![Image](https://trello-attachments.s3.amazonaws.com/60867cc6b7f287738b24d963/608686a8ae49fd4a937e4b41/c788a17186345ba2831b7481b465d9c3/image.png)

# Week 3
This week i had made the character movement and gravity, no graphics done. 
I had also made a save system with binaryformatter at first, but im going to change it to json type of saving and loading.

![image](https://user-images.githubusercontent.com/46887890/131046565-efa236e7-0415-49f5-8554-96b74553c1fa.png)

The picture is an updated pic, nothign changed other than the graphical side to it.
I did think of a character to make and enemy but in the end i decided that it would be for later.
I wanted to do the technical side first.


# Week 4
I have started the inventory and updating the save system.

![image](https://user-images.githubusercontent.com/46887890/131046763-dd102d1b-0b69-4e9e-af5e-e99995e8fe06.png)

This inventory was for the brewing system, i decided to make it look like a backpack.

I am making a main menu screen before playing the game. Made it only so you can have 4 save files max, if you want more you have to override the previous saves.

![image](https://user-images.githubusercontent.com/46887890/131046855-dae88d39-de1f-4f7a-9d63-df88895681e0.png)

My initial design was somethign like this but way less prettier. I have crossed out Options Bar annd Extras Bar on purpose as they have no function but it makes people want to come back and see if the game is updated after a bit of time will go by.

# Internval
I had started normal work and from then on I had not much done other then ideas drawn or written. In the end i nearly gave up on the whole project and year due to me thinking I can work alone. Only recently at week 9-10 i decided that i should at least try and do as much as possible. From week 4 to week 9 i had nothing done sadly, other than did work on brewing system.

# Week 10
I had decided to make a demo for my final project. Even though this demo will not have enemies or any life in terms of monsters or people i know that doing up the inventory and brewing system is more enjoyable than a really bad done up enemy or npc.

During the week I had made up the map and finalized an area for which the player can walk around. I had decided to take out most of the plants as they would be too much out of place in a snowy region. 
The brewing system nearly got done in week 9 and i had plans to make art for the plants but because of my own stupidity i had no more time left. I had to take something simple but still thought out for a design of plants and the brewing Tab.

Working on the brewing system was very hard, its not even fully finished but here are some lines of code that made me proud.

![image](https://user-images.githubusercontent.com/46887890/131047134-733271d9-01e9-4387-b316-7a7fd8fdbb4d.png)

The first picture was somethign we learned in another class than games development, when i first discovered this i really thought it was going to be useless.

![image](https://user-images.githubusercontent.com/46887890/131047189-fe1d2ebb-031e-4e8c-8054-a7c98e621d83.png)

even though the second picture is only moving an item to allocated slot, i was still proud as i had no clue how to do it and it took way more time than i would like to admit.
