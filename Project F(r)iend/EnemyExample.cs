if(enemyCharacter == "lightKiller")
{
    // Debug.Log(Mathf.Abs(player.transform.position.y - transform.position.y));
    if(Vector3.Distance(player.transform.position, transform.position) <= 20f 
    && !hasPlayedDetectSound 
    && Mathf.Abs(player.transform.position.y - transform.position.y) < 4f 
    && lightDectector.isActiveAndEnabled)
    {
        Debug.Log("walk tam");
        if(lightDectector.enabled == true)
        {
            this.agent.destination = player.transform.position;
        } 
    }
    else
    {
        Debug.Log("Mai dai walk tam");
    }
    if (playerDetected && Mathf.Abs(player.transform.position.y - transform.position.y) < 5f)
    {   
        if (enemyAlertSound != null && !hasPlayedDetectSound)
        {
            mSource.PlayOneShot(enemyAlertSound);
        }
        mSource.PlayOneShot(ChaseSoundTrack);
        hasPlayedDetectSound = true;

        isSeeking = false;
        isAttacking = true;
        this.agent.destination = player.transform.position;

        agent.stoppingDistance = distanceToAttackFrom;

        if (Vector3.Distance(transform.position, player.transform.position) > distanceToAttackFrom)
        {
            
            if(delayedAfterShoot)
            {
                PlayIdleAnim();
                agent.speed = 0;
            }
            else 
            {
                PlayRunAnim();
                agent.speed = runSpeed;
            } 
        }

        if (agent.remainingDistance <= distanceToAttackFrom)
        {
            if(delayedAfterShoot)
            {
                PlayIdleAnim();
                agent.speed = 0;
            }
            else
            { 
                PlayShootAnim();

                Vector3 pointToLook = new Vector3(player.transform.position.x, transform.position.y,player.transform.position.z);
                transform.LookAt(pointToLook);
                if (!playerIsDead && !hasFiredOne)
                {
                    StartCoroutine(addShootingRandomness());
                }
            }
        }
    }
}