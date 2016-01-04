# Pixalto
Group project for IGME.602

Theoretical Analysis of Gameplay and Rhetoric in Pixalto

Stein Astor Fernandez

Rochester Institute of Technology, New York

Developers
Anthony Zalar: Art, Production
Arun Krishnakumar: Level Design
Chengchen Yang: Programming
Reuben Brenner-Adams: Programming, Game Design
Roger Smith: Sound Design, Game Design
Stein Astor Fernandez: Level Design, Game Design


Theoretical Analysis of Gameplay and Rhetoric in Pixalto

Pixalto is a 2D side scrolling game where the player must maneuver a character through a series of levels, interacting with a variety of non player characters (NPCs) as they traverse the world.  This paper explores the concepts presented in Pixalto, with a focus on the rhetorical representation of interpersonal relationships and meaningful play. 

Rules and Mechanics

Levels and Characters

The player is represented by a green pixelated square, shaded with a gradient. The world is a setting where the player traverses levels populated by randomly coloured NPCs that are also represented by pixelated by squares that can be of any random colour but green. NPCs are randomly hostile (will charge at the player when he/she approaches within a certain distance and continues charging if the player remains within this distance), neutral (will wander around normally, ignoring the player) or timid (will flee from the player when he/she approaches within a certain distance). The player will also encounter a variety of platforming puzzles throughout the game. 

Mechanics

The objective of the game is to reach the end of the game. The NPCs and platforming puzzles will hinder the player from doing so and must be overcome. The player possesses the ability to fling or shoot a pixel at NPCs to defeat them. In doing so, the player’s character is visibly depleted of this pixel, becoming smaller. The player character possesses a limited number of pixels. Players also lose pixels on contact with NPCs of any kind. If the player character runs out of pixels, it dies and respawns at the beginning of the level (with the same number of pixels it had at that point originally). 

It is possible to get past the NPCs without defeating them. Initially, we only had two methods of dealing with NPCs - avoidance or combat. However, this created an unintentional rhetoric of those being the only two methods of interpersonal interaction. To solve this, we created an additional mechanic: if a player remains close enough to a neutral or timid NPC for a few seconds, the NPC shifts colours partially to mirror that of the player. These NPCs will no longer hurt the player upon contact. Upon successfully overcoming all NPCs and puzzles, reaching the end of a level will inform the player of how many NPCs remain alive in the level and grant them pixels for each NPC that remains alive. NPCs that have been “befriended” will award bonus pixels. The pixels the player receives are coloured in the same manner as the NPC that granted it to them. The appearance of the player thus changes at the end of each level. In the next level, the player now starts with the additional differently coloured pixels gained at the end of the previous level. 

Gameplay and Interactivity

Procedural Rhetoric

Bogost (2010) defines procedural rhetoric as “the practice of using processes persuasively” (p.28). In procedural rhetoric, arguments are created through the authorship of governing rules of behaviour. The advantage of procedural rhetoric lies in its unique capability to express and make claims about how things work (Bogost, 2010, p.29). In addition, procedural rhetoric can take advantage of the vividness of visual media without its limited dialectic capability (Bogost, 2010, p.29).

Video games often do not have an intentional rhetoric, or make their arguments in a non procedural fashion. However, video games are especially suited to procedural rhetoric due to their innate procedural intensiveness that is aimed at expression rather than utility, as opposed to software in general. This, combined with their interactivity, make them one of the ideal media with which to express rhetoric procedurally (Bogost, 2010, p.45).

The primary rhetoric we wanted to convey through the procedural mechanics of this game is how neither blind pacifism nor blind aggression in interpersonal relationships is desirable - there must be a balance. The consequences of each has also been rhetorically represented. 

At the start of the game, the player is instructed how to shoot at NPCs, but not of the consequences of doing so. This is left for the player to discover procedurally. Upon shooting a pixel at NPCs, their character becomes visibly damaged - a metaphor for how hurting others is never without cost. This holds true even if the player misses the shot - the mere attempt to inflict harm is enough, as in real life. 

The pixel that is shot at the NPC is also always the lightest shaded one available, regardless of colour. This is to represent how every time you deliberately try to hurt someone else, it is the brightest part of yourself that is lost. This also leads to the direct consequence that is mirrored in real life - with repeated attempts, what remains of you grows darker. This has the unfortunate side effect of conveying the racist idea that a darker appearance is reflective of undesirable internal characteristics, specifically aggression. For these reasons, we have removed this feature until it can be refined to remove the racist connotations from it, if possible. 

NPCs may be hostile, neutral or fearful, but it is impossible to tell them apart unless you approach them close enough. Much like when dealing with people, judgment ought to be deferred till appropriate. Destroying NPCs by shooting pixels at them will allow you to traverse the level easier, letting you take your time with the jumping puzzles and preventing you from potentially losing more pixels when they come in contact with you. The amount of pixels that will be lost on contact with NPCs is significantly more than one, incentivizing players to proactively deal with NPCs by shooting them on sight. This is akin to how one might, in real life, prevent people from getting too emotionally close to themselves for fear of getting hurt. After all the closer someone is to you, the more hurt they are capable of inflicting. 

The player also has the option of avoiding them entirely - not all NPCs may be worth befriending. Some NPCs may move in more complex patterns, or in circumstances that make it difficult for the player to befriend them - such as being in the middle of a platforming puzzle or close to a hostile NPC. Much like real life, not everyone is worth the effort to befriend them. 

Upon encountering a non hostile NPC, the player may attempt to stay close enough to them for a few seconds to befriend them. If successful, the non hostile NPC responds by shifting colours partially to grow more similar to that of the player. Metaphorically, this is representative of staying close to someone to gain their trust, without getting too close too quickly and risking hurt to yourself. 
Timid NPCs can be befriended as well, by trapping them against a wall and approaching carefully to maintain nearness without direct contact. The metaphorical representation is somewhat weak here - the correct way to deal with shy people is almost certainly not to chase them down and back them into a corner, physically or metaphorically. However, playtesting revealed that the alternative of having them unable to be befriended and posing no real threat does not make for interactive gameplay and also makes a weak metaphorical argument - viewing shy people as something to be ignored is not a positive argument either. Overall, timid NPCs are being considered an experimental feature at this point. 

At the end of each level, the player is rewarded for the number of NPCs left alive in the form of pixels from each remaining NPC being added to you. Through your travels and experience in interacting with others, you have grown as a person. Befriended NPCs award bonus pixels - friendships may not pay off immediately, but in the long run they help you become a better person. 

Meaningful Play

Salen and Zimmerman offer two definitions for meaningful play. The first, evaluative definition reads : “Meaningful play in a game emerges from the relationship between player action and system outcome; it is the process by which a player takes action within the designed system of a game and the system responds to the action. The meaning of an action in a game resides in the relationship between action and outcome” (Salen & Zimmerman, 2003, ch.3 p.4). 
The second, descriptive definition reads: “Meaningful play occurs when the relationships between actions and outcomes in a game are both discernable and integrated into the larger context of the game. Creating meaningful play is the goal of successful game design” (Salen and Zimmerman, 2003, ch.3 p.4).

The key terms in the latter definition are “discernable” and “integrated”. Discernable means that the result of the game action is communicated to the player in a perceivable way.  Discernability is key to allowing the player to understand the relationship between action and outcome, from which meaning arises. Integrated means that the relationship between action and outcome should be integrated into the larger context of the game. Deeper layers of meaning arise from the ways in which an action taken at one point in the game affect the play experience at a later point (Salen & Zimmerman, 2003, ch.3 p.4)

Throughout Pixalto, the player is presented with choices in how to interact with NPCs, with the game reacting with differing consequences based on their decisions. 

The primary meaningful choice that a player must make is of how to deal with the fact that NPCs hurt the player on contact. The player is given a direct tool to deal with this - shoot pixels, kill NPC. However, this also ends up hurting the player in the long run - as the player defeats more NPCs, they deplete their own pixels, leaving them weakened. Any misstep when the player is low on pixels might end up killing them altogether if they accidentally touch an NPC. This is communicated to the NPC by the visible and audible depletion of their own pixels each time they shoot, providing immediately discernible feedback to the player as a direct result of their action. 

The alternative course of action to deal with this is avoidance - just make sure not to touch the NPC and you will not lose any pixels, either from shooting them or being hurt. However, mistakes here are more costly. If you miss a shot, you lose a pixel. If you mistime a jump, you can lose significantly more by touching an NPC. If you successfully befriend or avoid an NPC, you are also rewarded with more pixels at the end of each level.

The discernible relationship between action and outcome is first expressed in a simple tutorial, to allow the player to easily deduce it without the added complexity of platforming or multiple NPCs. The player is introduced to one NPC at a time and informed of how to befriend an NPC and how to shoot, and allowed to safely observe the immediately visible consequences of each. 

Since all NPCs look the same from afar, the player must also consider their approach carefully. While the aggro radius of hostile NPCs is greater than the befriending radius of non hostile NPCs, it is still close enough for the player to exercise caution. Does the situation allow for safely avoiding the NPC or killing it if it turns out to be hostile on approach? Is it possible to befriend this NPC safely given the situation? The player must consider these options and decide whether to befriend, attack or avoid. 

In the context of the descriptive definition of meaningful play, the loss of pixels through attacking or being hurt by an NPC is an outcome discernible immediately to the player. When a player befriends a non hostile NPC successfully, the change in colour acts as an indicator for the integrated change - the addition of pixels at the end of the level acts as an integrated, long term outcome. This integrated change can also happen to a lesser degree by simply leaving NPCs alive, even if the player chooses not to befriend them. 

While it is important for the player to be allowed to discover the long-term consequences of their actions, the relationship between action and outcome must be made clear. To this end, we decided to add a congratulatory message at the end of each level, informing the player of the number of NPCs killed, spared and befriended as well as the amount of pixels gained. The player is expected to discover within a level or two at most that the number of pixels gained is proportional to the number of NPCs he has befriended or spared. Our limited initial playtesting supports this assumption, but more will be required to assess the effectiveness of this method. 

In conclusion, we have attempted to create compelling gameplay through meaningful choices - the player is encouraged to conserve pixels and weigh each situation carefully as well as their larger objective when deciding upon the appropriate course of action. 

Character

The Body, Imitation and Interpersonal Space

Isbister (2006) mentions that a way people display relationships through their bodies is imitation, mimicking the postures and movements of those around them (p.165). She regards it as a “powerful, missed design opportunity”(p.175). Though games like Spore (2008) have since been released, this is still a relatively unexplored design space. Isbister (2006) also talks about interpersonal distance - “One way to begin considering how bodies work in social interaction is to consider what proximity says about relationship” (p.162). In Pixalto, we have tried to embody the principles of both imitation and interpersonal distance in social interaction.

Upon encountering any NPC, the player must first consider their distance from it. Every NPC is a potential threat, and approaching one is always an exercise in caution. Hostile NPCs turn active when the player approaches within a certain distance, reacting aggressively to their personal space being encroached upon, forcing the player to find a way to avoid or combat them. Timid NPCs also react to their personal space being encroached upon, but by fleeing from the player. Neutral NPCs do not resort to either tactic when approached, but rather continue with their normal movement pattern, albeit slightly slowed as a cautious response to the proximity of the player. With each type of NPC, we have attempted to convey a distinct personality for each type of character through their body movement and the way they deal with interpersonal distance. To give further unique identity to each NPC, their colours are randomized with no bearing on personality type and unique movement patterns that they follow before being approached by the player. 

Upon encountering a non hostile NPC, the player may attempt to stay close enough to them for a few seconds to befriend them. Since the non hostile NPC is moving around on its own, the player is forced to mirror its movement in order to remain close without touching them. If successful, the non hostile NPC responds by shifting colours partially to grow more similar to that of the player. In both the action of the player and the reaction of the NPC, we see elements of imitation: the former in movement, and the latter in colour. This imitation is not performed explicitly, but rather arises naturally as a direct consequence of the player attempting to maintain an appropriate interpersonal distance with the other character. 

Once the player has successfully befriended the NPC, its colour transforms to partially match that of the player. In addition, its movement becomes noticeably placid in the presence of the player, calmed by the proximity of a friend. To reinforce this, direct contact with befriended NPCs no longer hurts the player. Thus, there is a distinct contrast between the interpersonal distance that the player must maintain depending on whether the NPC has been befriended or otherwise. 

At the end of each level, the player is awarded pixels based on the number of NPCs that remain alive. The pixels retain the colour of the NPC that awards them, and therefore the body of the player transitions from monochrome to multi-coloured, reflecting their growth as a person in the body of the character, through size and colour. 

Through the changing bodies, movements and interpersonal distances of both the players and NPCs, we have attempted to show how each of them is transformed by their interactions. 


Conclusion

Pixalto is a 2D Platformer designed with the intention of rhetorically showcasing interpersonal interactions while simultaneously creating compelling gameplay with meaningful decisions. 
Through creating gameplay procedures reflective of real life interpersonal interactions and representing characters using Isbister’s techniques focusing on the body, we form our intended procedural rhetoric.   
Through creating and adequately presenting meaningful, interesting choices with discernible and integrated outcomes for the player to discover and act upon, we arrive at meaningful play. 
References
Bogost, I. (2010). Persuasive Games: The Expressive Power of Videogames. Cambridge, MA: The MIT Press.
Salen, K., & Zimmerman, E. (2003). Rules of Play: Game Design Fundamentals. Cambridge, Mass: The MIT Press.
Isbister, K. (2006). The Body, Player-Characters, Nonplayer-Characters. In Better Game Characters by Design (pp. 162-181, 203-223, 225-252). Amsterdam: Morgan Kaufmann.





