#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import <GameKit/GameKit.h>

@interface IOSNativeLang : NSObject { }

+ (IOSNativeLang*) instance;

- (char *) getSysLang;

- (char *) cStringCopy : (const char *) str;

@end
