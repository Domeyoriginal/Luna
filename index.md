
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

With Week2 i will have much more to show for the blog, text and pictures included.

# Week 2
I messed around a lot with particles and ideas for a monster, didnt get far as i had trouble deciding on the final design.
Instead i did up a moon cycle since the world will never see the sun, i needed a moon to alwasy rotate around the world and have the light get darker and brighter depending on the moons position. I want it this way for a buff of the monsters when its darker. The monsters get better and stronger from taking power of the drakness.

I had also messed around with the design for the main character, and the other NPC's. With the help of a friend for designing characters we picked out that each non monster npc will we surroudned in cloth to keep warm. There is no sun so there is no heat. The world will also be in an ice-age of sorts becuase of the sun.
I had made a moon system which followed a Sin wave, it also changed the light intensity the lower or higher the moon is.
Below is the code for it :
```
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
```

