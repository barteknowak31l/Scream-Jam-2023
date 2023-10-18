using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface JumpscareSystem : CustomSystem
{
    public void Attach(Jumpscare p_Jumpscare);

    public void Trigger(Jumpscare p_Jumpscare);

    public void EndJumpscare(Jumpscare p_Jumpscare);

}
