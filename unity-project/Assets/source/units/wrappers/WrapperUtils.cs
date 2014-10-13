using System;

public static class WrapperUtils {
    public static Target Wrap<Target, Source> (Source field, Func<Source, Target> creator)
            where Source : class
            where Target : class {
        if (field == null) {
            return null;
        } else {
            return creator(field);
        }
    }
}
