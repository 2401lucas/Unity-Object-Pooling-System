using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPool : GenericObjectPool<ObjectTobePooled>
{
    public override void AddPoolReference(ObjectTobePooled objectToAddReference) => objectToAddReference.GetComponent<IObjectPool>().pool = this;
}
